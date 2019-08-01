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
    public partial class Reaction : Form
    {
        public List<Color> _listColor = new List<Color>
        {
            Color.DarkCyan,Color.Orange,Color.Green,Color.Orchid,Color.Lime,Color.Navy
        };
        SqlCommands cmd = new SqlCommands();
      
        Audio _audio = new Audio();

        Random rnd = new Random(5);
        Examiner exm ;
        int time = 0;
        int values = 0;
        int loops = 0;
        public Reaction()
        {
            InitializeComponent();
            Init();
            
        }
        public Reaction(Examiner _examiner)
        {
            InitializeComponent();
            exm = _examiner;
           
            _audio.Read(global::StatesExam.Properties.Resources.coloring);
        }
        public void Init()
        {
            
            if (loops++ < 5)
            {
                try
                {
                    lblLoop.Text = loops.ToString();
                    btnMainColor.BackColor = _listColor[rnd.Next(0, 15) - 1];
                    timer1.Start();
                }
                catch (Exception ex)
                {
                    loops--;
                   // MessageBox.Show(ex.Message);
                }
               
            }
            else
            {
                cmd.GetCMDConnection(DBCatalog.DB_Core.ToString(), String.Format("InsertIntoResults"), _cmd =>
                {
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.Parameters.AddWithValue("@barcode", exm.Barcode);
                    _cmd.Parameters.AddWithValue("@exm_id", 28);
                    _cmd.Parameters.AddWithValue("@exm_name", "رد الفعل");
                    _cmd.Parameters.AddWithValue("@fullMark", 200);
                    _cmd.Parameters.AddWithValue("@value", values);
                    _cmd.Parameters.AddWithValue("@duration", 2);

                    _cmd.ExecuteNonQuery();
                });
                _audio.GetCurrentPlayer().Stop();
                this.Close();
            }
        }

        private void btnMainColor_Click(object sender, EventArgs e)
        {
            Init();
            
        }

        private void pcl4_Click(object sender, EventArgs e)
        {
            var _this = (PictureBox)sender;

            if (_this.BackColor == btnMainColor.BackColor)
            {
                timer1.Stop();
                values += time;
                time = 0;
                Init();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = (time++).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Init();
            button3.Visible = false;
        }
    }
}
