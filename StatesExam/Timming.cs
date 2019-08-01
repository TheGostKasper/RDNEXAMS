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
    public partial class Timming : Form
    {
        SqlCommands cmd = new SqlCommands();
        Audio _audio = new Audio();

        Examiner exm;
        int time = 0;
        int values = 0;
        int loops = 4;
        int curr_loop=1;
        int i = 0;
        int exmCount = 72;

        public Timming()
        {
            InitializeComponent();
        }
      
        public Timming(Examiner _examiner)
        {
            exm = _examiner;
            InitializeComponent();
            _audio.Read(global::StatesExam.Properties.Resources.timming);
        }
       

        public void ResetCOlors()
        {
            for (int i = 0; i < exmCount; i++)
            {
                var opt = this.Controls.Find(String.Format("rplc{0}", (i + 1)), true);
                if (opt.Length > 0)
                {
                    opt[0].BackColor = Color.Green;
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Interval = loops * 20;
            timer1.Start();

            //var query = String.Format("BACKUP DATABASE [db_core] TO DISK={0}", @"'C:\app\db_core.bak'");

            //cmd.Catalog = "Db_core";

            //cmd.GetCMDConnection(query, _cmd =>
            //{
            //    _cmd.ExecuteNonQuery();
            //});
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (i++ == exmCount)
            {
                timer1.Stop();

                timer2.Start();
            }
            else
            {
                var next = this.Controls.Find(String.Format("rplc{0}", (i)), true);
                var pre = this.Controls.Find(String.Format("rplc{0}", (i - 1)), true);
                if (next.Length > 0)
                {
                    next[0].BackColor = Color.Red;
                    if (pre.Length > 0) pre[0].BackColor = Color.Green;
                }


            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (loops== 0)
            {
                var _values = (values > 100) ? 100 : 100 - values;
               
                timer2.Stop();
                timer1.Stop();

                cmd.GetCMDConnection(DBCatalog.DB_Core.ToString(), String.Format("InsertIntoResults"), _cmd =>
                {
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.Parameters.AddWithValue("@barcode", exm.Barcode);
                    _cmd.Parameters.AddWithValue("@exm_id", 29);
                    _cmd.Parameters.AddWithValue("@exm_name", "توقع زمني");
                    _cmd.Parameters.AddWithValue("@fullMark", 200);
                    _cmd.Parameters.AddWithValue("@value", values);
                    _cmd.Parameters.AddWithValue("@duration", 2);

                    _cmd.ExecuteNonQuery();
                });
                _audio.GetCurrentPlayer().Stop();
                this.Close();
            }
            else
            {
                --loops;
                lblLoop.Text = (++curr_loop).ToString();// loops.ToString();
                try
                {
                    ResetCOlors();
                    values += time;
                    time = 0; lblTime.Text = "0";
                    btnFinish.Enabled = false;
                    btnFinish.BackColor = Color.Green;
                    timer2.Stop();
                    i = 0;
                    timer1.Interval = (loops==0)?5:loops * 20;

                    timer1.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
               
            }


        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            lblTime.Text = (time++).ToString();
            btnFinish.Enabled = true;
            btnFinish.BackColor = Color.Red;
        }
    }
}
