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
    public partial class ExObservables : Form
    {
        SqlCommands cmd = new SqlCommands(DBCatalog.DB_Core.ToString());
        public ExObservables()
        {
            InitializeComponent();
            Init();
        }
        public void Init()
        {
            var query = String.Format(@"select ROW_NUMBER() OVER (Order by  sold_id) AS ID, sold_id 'Solider-ID', ex_name 'Fullname' from t_examiners where sold_id not in (select sold_id from interview)");

            cmd.TableCMD(query, _dt =>
            {
                dataGridView1.DataSource = _dt;
            });
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void btnInterview_Click(object sender, EventArgs e)
        {
            Init();
        }

        private void btnFinishedExms_Click(object sender, EventArgs e)
        {
            var query = String.Format(@"select ROW_NUMBER() OVER (Order by  sold_id) AS ID, sold_id, ex_name, ex_year+ex_stage as stage from t_examiners where sold_id not in (select distinct sold_id from t_results)");

            cmd.TableCMD(query, _dt =>
            {
                dataGridView1.DataSource = _dt;
            });
        }

      
    }
}
