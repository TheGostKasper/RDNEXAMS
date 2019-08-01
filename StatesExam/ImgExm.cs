using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StatesExam.Helper;

namespace StatesExam
{
    public partial class ImgExm : Form
    {
        public Answers curr_obj = new Answers();
        SqlCommands cmd = new SqlCommands();
        public int index_glob = 0;
        Audio audio = new Audio();

        public List<Questions> _listQ = new List<Questions>();
        //public List<Questions> _listEXMS = new List<Questions>();
        public List<Answers> _listAns = new List<Answers>();

        public List<Results> _listResults = new List<Results>();
        public Examiner _examiner { get; set; }

        string currExmsIds, currDBCatalog = "";

        byte[] curr_audio = null;
        private bool autoPlay = true;
        int curr_qus_id = 0;

        bool spieces, math = false;
        List<String> _ids = new List<string>();


        public int minutes = Assigner.durations;
        public int seconds = 59;


        public ImgExm()
        {
            InitializeComponent();

        }

        public ImgExm(Examiner exem)
        {
            InitializeComponent();
            _examiner = exem;
            currDBCatalog = cmd.Catalog;
            GetExms();
            ExmTimeDuration();
            Init();
        }


        public void ExmTimeDuration()
        {
            cmd.Catalog = DBCatalog.DB_Exam_Engine.ToString();

            int idx = (currExmsIds[currExmsIds.Length - 1] == ',') ? currExmsIds.LastIndexOf(",") : -1;
            currExmsIds = (idx >= 0) ? currExmsIds.Remove(idx, 1) : currExmsIds;

            var query = String.Format(@"select SUM(Exm_Duration_In_Mins) from t_exams where Exm_ID in ({0})", currExmsIds);

            cmd.GetCMDConnection(query, _cmd =>
            {
                var res = _cmd.ExecuteScalar();
                if (int.Parse(res.ToString()) > 0)
                    minutes = int.Parse(res.ToString());
            });
            currDBCatalog = cmd.Catalog = DBCatalog.DB_Core.ToString();
        }
        public void GetExms()
        {
            currDBCatalog = cmd.Catalog = DBCatalog.DB_Core.ToString();
            cmd.ReaderCMD(String.Format(@"select * from t_assigned_exams"), _reader =>
            {
                var curr_exm_id = "";
                while (_reader.Read())
                {
                    curr_exm_id += String.Concat(_reader.GetValue(0).ToString(), ",");
                }
                currExmsIds = curr_exm_id;
            });
        }

        public List<String> GetExaminedIds()
        {
            GetExms();
            cmd.ReaderCMD(String.Format(@"select rs_exam_id from t_results where rs_barcode='{0}'", _examiner.Barcode), _reader =>
            {
                while (_reader.Read())
                {
                    _ids.Add(_reader.GetValue(0).ToString());
                }
            });
            return _ids;
        }

        public List<String> GetMissedIds()
        {
            _ids = GetExaminedIds();
            var count = currExmsIds.Split(',').ToList();
            for (int i = 0; i < _ids.Count; i++)
            {
                count.Remove(_ids[i].ToString());
            }
            return count;
        }


        public void Init()
        {
            DisplayExams();
            cmd.Catalog = currDBCatalog;
            currExmsIds = RetStrIds();
            int idx = (currExmsIds[currExmsIds.Length - 1] == ',') ? currExmsIds.LastIndexOf(",") : -1;
            currExmsIds = (idx >= 0) ? currExmsIds.Remove(idx, 1) : currExmsIds;
            if (currExmsIds != "")
            {
                timer1.Start();
                cmd.Catalog = DBCatalog.DB_Exam_Engine.ToString();
                var query = String.Format(@"select exm_id, exm_name, exm_display_name ,exm_duration_in_mins,  qus_id , qus_text, qus_audio,qus_is_pic from 
                                            t_questions inner join t_exams on exm_id=qus_exm_id where exm_id in ({0}) ", currExmsIds);
                cmd.ReaderCMD(query
                , _reader =>
                {
                    while (_reader.Read())
                    {
                        _listQ.Add(new Questions
                        {
                            Exam_id = int.Parse(_reader.GetValue(0).ToString()),
                            Exam_name = _reader.GetValue(1).ToString(),
                            Display_name = _reader.GetValue(2).ToString(),
                            Duration = int.Parse(_reader.GetValue(3).ToString()),
                            Qus_id = int.Parse(_reader.GetValue(4).ToString()),
                            Qus_text = _reader.GetValue(5).ToString(),
                            Qus_audio = (_reader.GetValue(6).ToString() == "") ? null : (byte[])_reader.GetValue(6),
                            // Qus_image = ConvertByteToImage(_reader.GetValue(7))
                            Qus_is_pic = Convert.ToBoolean(_reader.GetValue(7))
                        });
                    }

                    if (Assigner.IsRandomized)
                        RandomizeQuestion(_listQ);


                    GetQuestionsIfExamined();
                });
            }
            else
            {
                MessageBox.Show("انتهي الاختبار !");

                this.Close();
                _listResults.Clear();
                timer1.Stop();
            }
        }

        public string RetStrIds()
        {
            var str = "";
            foreach (var item in GetMissedIds())
            {
                str += item.ToString() + ",";
            }

            return str.Replace(",,", "");
        }
        private void DisplayExams()
        {
            cmd.Catalog = currDBCatalog;

            CheckExame(28, _exm => new Reaction(_exm).ShowDialog());
            CheckExame(2, _exm => new ReHearing(_exm).ShowDialog());
            CheckExame(29, _exm => new Timming(_exm).ShowDialog());
        }

        public void CheckExame(int ex_id, Action<Examiner> callback)
        {
            if (_ids.FirstOrDefault(e => e == ex_id.ToString()) == null && currExmsIds.Split(',').FirstOrDefault(e => e == ex_id.ToString()) != null)
            {
                if (CheckExameFinished(ex_id, _examiner.Barcode) == 0)
                {
                    callback(_examiner);
                }
            }
        }
        public void CheckFinishedExame(int ex_id, Action<Examiner> callback)
        {
            if (currExmsIds.Split(',').FirstOrDefault(e => e == ex_id.ToString()) != null)
            {
                if (CheckExameFinished(ex_id, _examiner.Barcode) == 0)
                {
                    callback(_examiner);
                }
            }
        }
        public void GetQuestionsIfExamined()
        {
            try
            {
                cmd.GetCMDConnection(String.Format(@"GetExaminedQuestions"), _cmd =>
                {
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.Parameters.AddWithValue("@examiner", _examiner.Barcode);

                    var _reader = _cmd.ExecuteReader();
                    int count = 0;
                    while (_reader.Read())
                    {
                        count++;
                        var question = new Questions
                        {
                            Exam_id = int.Parse(_reader.GetValue(2).ToString()),
                            Duration = int.Parse(_reader.GetValue(4).ToString()),
                            Exam_name = _reader.GetValue(3).ToString()
                        };
                        var obj = new Answers
                        {
                            Ans_text = _reader.GetValue(0).ToString(),
                            Ans_value = int.Parse(_reader.GetValue(1).ToString()),
                            Qus_id = int.Parse(_reader.GetValue(5).ToString()),
                            Ans_id = int.Parse(_reader.GetValue(6).ToString())
                        };

                        var _checked = _listResults.FirstOrDefault(rs => rs.Exam_id == question.Exam_id && rs.Sold_id == _examiner.Sold_id);
                        if (_checked != null)
                        {
                            var listAnswers = _checked.ListAnswers.FirstOrDefault(ans => ans.Qus_id == obj.Qus_id);
                            if (listAnswers != null)
                            {
                                listAnswers.Ans_value = obj.Ans_value;
                                listAnswers.Ans_text = obj.Ans_text;
                            }
                            else _checked.ListAnswers.Add(obj);
                        }
                        else
                        {
                            var listAns = new List<Answers>();
                            listAns.Add(obj);
                            _listResults.Add(new Results
                            {
                                Barcode = _examiner.Barcode,
                                Sold_id = _examiner.Sold_id,
                                Exam_id = question.Exam_id,
                                Exam_duration = question.Duration,
                                Exam_name = question.Exam_name,
                                ListAnswers = listAns
                            });
                        }

                    }

                    GetItem((count == 0) ? 1 : count);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        bool eyeNoticed = false;
        public void DisplayCurrentQuestion(Questions item, Action<Questions> callback)
        {
            var _first = item;
            if (_first != null)
            {
                if (item.Exam_id == 3 && eyeNoticed == false)
                {
                    eyeRem.Visible = eyeNoticed = true;
                    timer2.Start();
                }

                ResetBtnColors();

                lblexam.Text = String.Format(@" الفقرة الحالية :{0}", _first.Display_name.ToString());
                lblExmTxt.Text = _first.Qus_text.ToString();
                lblShortCut.Text = String.Format(@"({1}/{0}) اجمالي الأسئلة", index_glob + 1, _listQ.Count().ToString());

                callback(_first);
            }
        }


        public void GetItem(int additions)
        {
            if (audio.GetCurrentPlayer() != null) audio.GetCurrentPlayer().Stop();
            var _next = _listQ.FindIndex(e => (e.Qus_text == lblExmTxt.Text && e.Qus_is_pic != true) || e.Qus_id == curr_qus_id);
            index_glob = _next + additions;
            btnPre.Enabled = (_next >= 0) ? true : false;
            btnNext.Enabled = (_next <= _listQ.Count) ? false : true;
            if (!btnNext.Enabled) panel1.Focus();

            if (_next + additions < _listQ.Count && index_glob >= 0)
            {
                var nextItem = _listQ[index_glob];
                DisplayCurrentQuestion(nextItem, qus =>
                {

                    if (math == false && qus.Exam_id == 6)
                    {
                        math = true; audio.Read(global::StatesExam.Properties.Resources.math);
                    }



                    if (spieces == false && qus.Exam_id == 1)
                    {
                        spieces = true; audio.Read(global::StatesExam.Properties.Resources.species);
                    }


                    curr_qus_id = qus.Qus_id;
                    if (qus.Qus_is_pic)
                    {
                        cmd.GetCMDConnection(String.Format(@"select qus_image from t_questions where qus_id={0}", qus.Qus_id), _cmd =>
                        {
                            var res = _cmd.ExecuteScalar();
                            pictureBox1.Image = ConvertByteToImage(res);

                        });
                        lblExmTxt.Visible = false;
                        pictureBox1.Visible = true;

                    }
                    else
                    {
                        lblExmTxt.Visible = true;
                        pictureBox1.Visible = false;
                    }
                    GetAnswers(qus.Qus_id);
                    curr_audio = qus.Qus_audio;
                    if (autoPlay) { audio.Read(qus.Qus_audio); }
                    lblShortCut.Text = String.Format(@"({1}/{0}) اجمالي الأسئلة", index_glob + 1, _listQ.Count().ToString());
                });
            }

            if (_next == _listQ.Count - 1)
            {
                CheckFinishedExame(28, _exm => new Reaction(_exm).ShowDialog());
                CheckFinishedExame(2, _exm => new ReHearing(_exm).ShowDialog());
                CheckFinishedExame(29, _exm => new Timming(_exm).ShowDialog());

                InsertToDB();
                FreeDummyBackUp(_examiner.Barcode);
            }
        }


        public void GetAnswers(int qus_id)
        {
            //cmd.Catalog = "DB_Exam_engine_1";
            cmd.ReaderCMD(String.Format(@"select ans_id , Ans_text , ans_value ,ans_image,ans_is_pic from t_answers where ans_qus_id ={0}", qus_id)
           , _reader =>
           {
               _listAns.Clear();
               while (_reader.Read())
               {


                   _listAns.Add(new Answers
                   {
                       Ans_id = int.Parse(_reader.GetValue(0).ToString()),
                       Ans_text = _reader.GetValue(1).ToString(),
                       Ans_value = int.Parse(_reader.GetValue(2).ToString()),
                       Ans_Image = (_reader.GetValue(3).ToString() == "") ? null : (byte[])_reader.GetValue(3),
                       Qus_id = qus_id,
                       Ans_Pic = Convert.ToBoolean(_reader.GetValue(4))
                   });
               }
               DisplayAnswers(_listAns);
           });
        }

        public Image ConvertByteToImage(object source)
        {
            var img = source;
            if (img != null && !String.IsNullOrEmpty(img.ToString()))
                using (var s = new MemoryStream((byte[])img))
                {

                    var _srcImg = Image.FromStream(s);

                    return _srcImg;
                }
            return null;
        }
        private void DisplayAnswers(List<Answers> _listAns)
        {
            if (index_glob >= 0)
                SetControls(_listAns);
            if (index_glob == 0) btnPre.Enabled = false;

        }

        public void SetControls(List<Answers> _listAns)
        {
            ansPanel.Controls.Clear();
            var x = 46; var y = 14;
            var XValue = x; var YValue = y;
            for (int i = 0; i < _listAns.Count; i++)
            {
                var pcm = new Control();
                var item = _listAns[i];

                if (item.Ans_Image != null)
                {
                    btnMute.Visible = false;
                    if ((x * ((i * 6) + 1)) + 241 > ansPanel.Width)
                    {
                        x = 46;
                        XValue = x * (((i - 4) * 6) + 1); YValue = 173;
                    }
                    else
                    {
                        XValue = x * ((i * 6) + 1); YValue = y;
                    }

                    pcm = new PictureBox
                    {
                        Image = ConvertByteToImage(_listAns[i].Ans_Image),
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Size = new System.Drawing.Size(241, 119),
                        BackColor = Color.Silver,
                        // Padding=Padding.All(3),
                        Location = new Point(XValue, YValue),
                        Name = item.Ans_id.ToString()
                    };
                }

                else
                {
                    btnMute.Visible = true;
                    pcm = new Button
                    {
                        Width = 1150,
                        Height = 82,
                        Location = new Point(18, 18 + (82 * i)),
                        Name = item.Ans_id.ToString(),
                        BackColor = Color.Silver,
                        Font = new Font("Arial", 30, FontStyle.Bold),
                        Text = item.Ans_text
                    };
                }
                //pcm.KeyUp += (obj, s) =>
                //{
                //     Next();
                //};

                pcm.Click += (obj, s) =>
                {

                    var options = new List<Control>();
                    for (int j = 0; j < _listAns.Count; j++)
                    {
                        var btn = ansPanel.Controls.Find(_listAns[j].Ans_id.ToString(), true);
                        options.Add(btn[0]);
                    }

                    var wtf = obj.GetType();
                    if (obj.GetType().Name == "Button")
                    {
                        options.ForEach(e =>
                        {
                            if (e.Name != ((Button)obj).Name) e.BackColor = Color.Silver;
                            else e.BackColor = Color.Maroon;
                        });

                    }
                    else
                    {
                        // options.FirstOrDefault(e => e.Name == ((PictureBox)obj).Name).BackColor = Color.Red;
                        options.ForEach(e =>
                        {
                            if (e.Name != ((PictureBox)obj).Name) e.BackColor = Color.Silver;
                            else e.BackColor = Color.Maroon;
                        });
                    }


                    btnNext.Enabled = true;
                    btnNext.Focus();
                    curr_obj = _listAns.FirstOrDefault(_ans => _ans.Qus_id == _listQ[index_glob].Qus_id && _ans.Ans_id == int.Parse(pcm.Name));
                };
                ansPanel.Controls.Add(pcm);

            }
        }


        private void btnPre_Click(object sender, EventArgs e)
        {

            GetItem(-1);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Next();
        }

        public void Next()
        {
            var question = _listQ[index_glob];
            var obj = curr_obj;
            var _checked = _listResults.FirstOrDefault(rs => rs.Exam_id == question.Exam_id && rs.Sold_id == _examiner.Sold_id);
            if (_checked != null)
            {
                var listAnswers = _checked.ListAnswers.FirstOrDefault(ans => ans.Qus_id == curr_obj.Qus_id);
                if (listAnswers != null)
                {
                    listAnswers.Ans_value = curr_obj.Ans_value;
                    listAnswers.Ans_text = curr_obj.Ans_text;
                }
                else _checked.ListAnswers.Add(curr_obj);
            }
            else
            {
                var listAns = new List<Answers>();
                listAns.Add(curr_obj);
                _listResults.Add(new Results
                {
                    Barcode = _examiner.Barcode,
                    Sold_id = _examiner.Sold_id,
                    Exam_id = question.Exam_id,
                    Exam_duration = question.Duration,
                    Exam_name = question.Exam_name,
                    ListAnswers = listAns
                });
            }
            DummBackUps();
            GetItem(1);
        }
        public void DummBackUps()
        {
            try
            {
                cmd.GetCMDConnection(String.Format(@"InsertToDumBackUp"), _cmd =>
                {
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.Parameters.AddWithValue("@Ex_Id", _examiner.Barcode);
                    _cmd.Parameters.AddWithValue("@Ex_ans_Id", curr_obj.Ans_id);
                    _cmd.Parameters.AddWithValue("@Ex_qus_id", curr_obj.Qus_id);
                    _cmd.Parameters.AddWithValue("@Ex_value", curr_obj.Ans_value);

                    _cmd.ExecuteNonQuery();
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void RandomizeQuestion(List<Questions> _list)
        {
            var currList = new List<Questions>();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    try
                    {
                        var idx = i + (10 * j);
                        if (idx <= _listQ.Count)
                        {
                            var cq = _listQ[idx];
                            currList.Add(cq);
                        }
                        else
                        {
                            idx = i + (10 * j);
                        }

                    }
                    catch (Exception ex)
                    {
                        break;
                    }
                }
            }

            _listQ = (currList.Count > 0) ? currList : _listQ;
        }

        public void InsertToDB()
        {
            try
            {
                foreach (var item in _listResults)
                {
                    var values = item.ListAnswers.Select(e => e.Ans_value).Sum();

                    cmd.GetCMDConnection(DBCatalog.DB_Core.ToString(), String.Format("InsertIntoResults"), _cmd =>
                    {
                        _cmd.CommandType = CommandType.StoredProcedure;
                        _cmd.Parameters.AddWithValue("@barcode", item.Barcode);
                        _cmd.Parameters.AddWithValue("@exm_id", item.Exam_id);
                        _cmd.Parameters.AddWithValue("@exm_name", item.Exam_name);
                        _cmd.Parameters.AddWithValue("@fullMark", 50);
                        _cmd.Parameters.AddWithValue("@value", values);
                        _cmd.Parameters.AddWithValue("@duration", item.Exam_duration);

                        _cmd.ExecuteNonQuery();
                    });
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show("انتهي الاختبار !");

                this.Close();
                _listResults.Clear();
                timer1.Stop();
            }
        }

        private void FreeDummyBackUp(string p)
        {
            cmd.Catalog = DBCatalog.DB_Exam_Engine.ToString();
            cmd.GetCMDConnection(String.Format("delete from DumBackUp where ex_id='{0}'", p), _cmd =>
            {
                _cmd.ExecuteNonQuery();
            });
        }

        public int CheckExameFinished(int _id, string barcode)
        {
            var res = 0;
            var query = String.Format("select count(*) from t_results where rs_barcode='{1}' and rs_exam_id={0}", _id, barcode);
            cmd.Catalog = DBCatalog.DB_Core.ToString();
            cmd.GetCMDConnection(query, _cmd =>
            {
                res = int.Parse(_cmd.ExecuteScalar().ToString());
            });
            return res;
        }
        public void CheckIfexist()
        {
            //cmd.GetCMDConnection(Users.DB_Catalog,
            //    String.Format(@"selct count(*) from  "), _cmd =>
            //{

            //    _cmd.ExecuteNonQuery();
            //});
        }
        private void Exams_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (audio.GetCurrentPlayer() != null)
                audio.GetCurrentPlayer().Stop();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            //btnNext.Enabled = true;
            //btnYes.BackColor = Color.Green;
            //curr_obj = _listAns.FirstOrDefault(_ans => _ans.Qus_id == _listQ[index_glob].Qus_id && _ans.Ans_text == btnNo.Text);

            //btnNo.BackColor = Color.GreenYellow;
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            //btnNext.Enabled = true;
            //btnYes.BackColor = Color.GreenYellow;
            //curr_obj = _listAns.FirstOrDefault(_ans => _ans.Qus_id == _listQ[index_glob].Qus_id && _ans.Ans_text == btnYes.Text);
            //btnNo.BackColor = Color.Red;
        }
        public void ResetBtnColors()
        {
            //btnYes.BackColor = Color.Green;
            //btnNo.BackColor = Color.Red;
        }
        private void btnPause_Click(object sender, EventArgs e)
        {
            audio.GetCurrentPlayer().Stop();
            btnPlay.Enabled = true;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (curr_audio != null) audio.Read(curr_audio);
            else
            {
                audio.GetCurrentPlayer().Play();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            seconds--;

            if (seconds == 0)
            {
                minutes--;
                if (minutes < 0)
                {
                    InsertToDB();
                    FreeDummyBackUp(_examiner.Barcode);
                    timer1.Stop();
                }
                seconds = 59;
            }
            lblDuration.Text = string.Format("{0}:{1}", minutes, seconds);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            autoPlay = !autoPlay;
            var _this = ((Button)sender);
            if (!autoPlay)
            {
                btnPlay.Visible = btnPause.Visible = false;
                _this.BackColor = Color.Gray;
                _this.Text = "تشغيل الصوت";
            }
            else
            {
                btnPlay.Visible = btnPause.Visible = true;
                _this.BackColor = Color.Red;
                _this.Text = "كتم الصوت";
            }
            audio.GetCurrentPlayer().Stop();
        }
        int sec = 10;
        private void timer2_Tick(object sender, EventArgs e)
        {
            sec--;
            if (sec == 0)
            {
                timer2.Stop();
                eyeRem.Visible = false;
            }
        }

        private void ImgExm_KeyUp(object sender, KeyEventArgs e)
        {
            var key = e.KeyCode;
            if (key == Keys.Space)
            {
                Next();
            }
        }
    }

}
