using StatesExam.Helper;
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

namespace StatesExam
{
    public partial class UserInfoEntry : Form
    {
        Audio audio = new Audio();
        SqlCommands cmd = new SqlCommands();
        Examiner exm = new Examiner();
        public UserInfoEntry()
        {
            InitializeComponent();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetSoliderData();
        }
        public void GetSoliderData()
        {
            var queryMrz = String.Format(@"select  t.ex_barcode, t.sold_id, ex_name,ex_year, ex_stage ,g.gv_name from t_examiners t inner join t_governs g on ex_mohafza_code = gv_id
                                where t.sold_id='{0}' or ex_barcode='{0}'", txtSolSearch.Text);

            cmd.GetCMDConnection(DBCatalog.DB_Core.ToString(), queryMrz,
                _cmd =>
                {
                    var results = _cmd.ExecuteReader();
                    if (!results.HasRows) MessageBox.Show("تأكد من الرقم العسكري او الثلاثي مرة اخري !");

                    while (results.Read())
                    {
                        exm.Barcode = txtBarcode.Text = results.GetValue(0).ToString();
                        exm.Name = txtName.Text = results.GetValue(2).ToString();
                        exm.Sold_id = txtSold.Text = results.GetValue(1).ToString();

                        txtYear.Text = results.GetValue(3).ToString();
                        txtStage.Text = results.GetValue(4).ToString();
                        txtArea.Text = results.GetValue(5).ToString();

                        btnStart.Enabled = true;
                    }
                });
        }
        private void button1_Click(object sender, EventArgs e)
        {
            btnMute.Visible = true;
            audio.Read(global::StatesExam.Properties.Resources.introduction);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (CheckIfDone()) MessageBox.Show("تم اجراء الاختبار مسبقا");
            else
            {
                //this.Close();
                FreeControls(new List<Control> { txtArea, txtBarcode, txtName, txtSold, txtSolSearch, txtStage, txtYear });
                txtSolSearch.Focus();
                new ImgExm(exm).ShowDialog();
            }
            
        }
        public bool CheckIfDone()
        {
            var _res = false;
            cmd.GetCMDConnection(DBCatalog.DB_Core.ToString(),
               String.Format(@"select count(*) , (select count(*) from T_Assigned_Exams) from t_results where  rs_barcode='{0}' and rs_exam_id in (select Ae_exam_id from T_Assigned_Exams)", exm.Barcode),
               _cmd =>
               {
                   var results = _cmd.ExecuteReader();
                   while (results.Read())
                   {
                       _res = (int.Parse(results.GetValue(0).ToString()) == int.Parse(results.GetValue(1).ToString())) ? true : false;
                   }
               });
            return _res;
        }

        private void UserInfoEntry_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopPlayer();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            btnMute.Visible = false;
            StopPlayer();
        }
        public void FreeControls(List<Control> _controls)
        {
            foreach (var item in _controls)
            {
                var _item = (TextBox)item;
                _item.Text = "";
            }
        }
        public void StopPlayer()
        {
            var pr = audio.GetCurrentPlayer();
            if (pr != null)
                pr.Stop();
        }

        private void txtSolSearch_KeyUp(object sender, KeyEventArgs e)
        {
            var key = e.KeyCode;
            if (key == Keys.Enter && txtSolSearch.Text!="")
            {
                GetSoliderData();
                btnStart.Focus();
            }
        }

       
    }
}
