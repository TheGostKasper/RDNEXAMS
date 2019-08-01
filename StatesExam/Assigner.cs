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
    public partial class Assigner : Form
    {
        SqlCommands cmd = new SqlCommands(DBCatalog.DB_Core.ToString());
        public static int durations = 30;
        public static bool IsRandomized = true;
        string currExmsIds = "";
        public Assigner()
        {
            InitializeComponent();
            GetExms();
            Init();
        }
        public void Init()
        {
            cmd.Catalog = DBCatalog.DB_Exam_Engine.ToString();

            int idx = (currExmsIds[currExmsIds.Length - 1] == ',') ? currExmsIds.LastIndexOf(",") : -1;
            currExmsIds = (idx >= 0) ? currExmsIds.Remove(idx, 1) : currExmsIds;

            var query = String.Format(@"select SUM(Exm_Duration_In_Mins) from t_exams where Exm_ID in ({0})", currExmsIds);
           
            cmd.GetCMDConnection(query, _cmd =>
            {
                var res=_cmd.ExecuteScalar();
               numericUpDown1.Value= durations = int.Parse(res.ToString());
            });
        }
        public void GetExms()
        {
            cmd.Catalog = DBCatalog.DB_Core.ToString();
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
       
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            IsRandomized = (comboBox1.Text == "عشوائي") ? true : false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                durations = int.Parse(numericUpDown1.Value.ToString());
                IsRandomized = (comboBox1.Text == "عشوائي") ? true : false;
                MessageBox.Show("تم الحفظ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
