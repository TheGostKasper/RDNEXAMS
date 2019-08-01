using StatesExam.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StatesExam
{
    public partial class LoadingPage : Form
    {
        SqlCommands cmd = new SqlCommands(DBCatalog.DB_Exam_Engine.ToString());
        public LoadingPage()
        {
            InitializeComponent();
            var db = DBCatalog.DB_Exam_Engine.ToString();
            var dbNazary = DBCatalog.DB_Core.ToString();
        }

        private void LoadingPage_Load(object sender, EventArgs e)
        {
            AuthenticationManager();
        }
        public void AuthenticationManager()
        {
            
        }

        public void InsertAnswers()
        {
            for (int i = 101; i < 102; i++)
            {
                cmd.ReaderCMD(String.Format(@"select qus_id,qus_exm_id from t_questions where qus_exm_id={0} ", i), _reader =>
                {
                    while (_reader.Read())
                    {
                        //MessageBox.Show(_reader.GetValue(1).ToString());
                        cmd.GetCMDConnection(String.Format(@"insert into t_answers values({0},0,'نعم',NULL,2,Null,null) ; 
                                                             insert into t_answers values({0},0,'لا',NULL,1,Null,null)", _reader.GetValue(0)), _cmd =>
                        {
                            _cmd.ExecuteNonQuery();
                            //MessageBox.Show(_cmd.ExecuteNonQuery().ToString());
                        });
                    }
                });
            }

        }

        private void observableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ExObservables().Show();
        }
        private void examinersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           // new InsertExaminers().ShowDialog();
        }

        private void assignerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new InsertExaminers().ShowDialog();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            this.Hide();
            new UserInfoEntry().ShowDialog();
            this.Dispose();
            //InsertAnswers();
        }

        private void newINtv_Click(object sender, EventArgs e)
        {
            new Interview().Show();
        }

        private void exmsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Assigner().Show();
        }

       
    }
}
