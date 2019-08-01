using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StatesExam.Helper;

namespace StatesExam
{
    public partial class ReHearing : Form
    {
        SqlCommands cmd = new SqlCommands();

        Audio _audio = new Audio();
        Examiner _exm;
        int values = 0;
        int count = 0;
        List<String> _trueWordsList = new List<String>
        {
            "سيارة", "سالب","بدلة","انتقام", "جمل","مسلسل","شباك","كمثري","باخرة","مانجو"
        };
        public ReHearing()
        {
            InitializeComponent();
        }
        public ReHearing(Examiner _examiner)
        {
            InitializeComponent();
            _exm = _examiner;
        }
        private void button33_Click(object sender, EventArgs e)
        {
            pnlWords.Visible = true;
            btnStart.Enabled = btnHearing.Enabled = btnIntro.Enabled = false;
            if (_audio.GetCurrentPlayer() != null)
                _audio.GetCurrentPlayer().Stop();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var _wrd = _trueWordsList.FirstOrDefault(word => word == btn.Text);
            if (_wrd != null) values++;

            btn.Visible = false;

            count++;
            if (count == 10)
            {
                cmd.GetCMDConnection(DBCatalog.DB_Core.ToString(), String.Format("InsertIntoResults"), _cmd =>
                {
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.Parameters.AddWithValue("@barcode", _exm.Barcode);
                    _cmd.Parameters.AddWithValue("@exm_id", 2);
                    _cmd.Parameters.AddWithValue("@exm_name", "التذكر السمعي");
                    _cmd.Parameters.AddWithValue("@fullMark", 10);
                    _cmd.Parameters.AddWithValue("@value", values);
                    _cmd.Parameters.AddWithValue("@duration", 2);

                    _cmd.ExecuteNonQuery();
                });
                _audio.GetCurrentPlayer().Stop();

                this.Close();
            }
        }

        private void btnIntro_Click(object sender, EventArgs e)
        {
            _audio.Read(global::StatesExam.Properties.Resources.word_intro);

        }

        private void btnHearing_Click(object sender, EventArgs e)
        {
            _audio.Read(global::StatesExam.Properties.Resources.words);
            btnStart.Enabled = true;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            pnlWords.Visible = true;
            btnStart.Enabled = btnHearing.Enabled = btnIntro.Enabled = false;
            if (_audio.GetCurrentPlayer() != null)
                _audio.GetCurrentPlayer().Stop();
        }
    }
}
