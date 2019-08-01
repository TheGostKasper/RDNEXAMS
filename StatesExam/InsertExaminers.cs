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
    public partial class InsertExaminers : Form
    {
        SqlCommands cmd = new SqlCommands();
        FillComboValues fcmb = new FillComboValues();
        DummyCombo currQualification = new DummyCombo();
        public InsertExaminers()
        {
            InitializeComponent();
            cmd.Catalog = DBCatalog.DB_Core.ToString();
            Init();
        }


        public void Init()
        {
            //fcmb.GetQualificationAreas(drpQualification);
            //fcmb.GetStages(drpStage);
        }
        public void GetGoverns(ComboBox cmx, int regionId)
        {
            cmd.ReaderCMD(String.Format(String.Format(@"select * from t_governs where gv_rg_id={0}", regionId)), _reader =>
            {
                FillFReader(_reader, cmx);
            });
        }
        public void FillFReader(System.Data.SqlClient.SqlDataReader _reader, ComboBox cmx)
        {
            cmx.Items.Clear();
            while (_reader.Read())
                cmx.Items.Add(new DummyCombo { Value = int.Parse(_reader.GetValue(0).ToString()), Text = _reader.GetValue(1).ToString() });
            cmx.DisplayMember = "Text";
            if (cmx.Items.Count > 0)
                cmx.SelectedIndex = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var ctrls = new List<Object> { txtfullName, txtYear, txtSold_id, txtNationalId };
            if (CheckValidations(ctrls))
            {
                var governs = (DummyCombo)drpGoverns.SelectedItem;
                var query = String.Format("insert into t_examiners values('{0}','{1}','{2}','{3}',{4},{5},'{6}')", txtSold_id.Text, txtfullName.Text, txtYear.Text, int.Parse(drpStage.Text), currQualification.Value, governs.Value, txtNationalId.Text);

                if (!CheckIfExist())
                    cmd.GetCMDConnection(query, _cmd =>
                    {
                        var res = _cmd.ExecuteNonQuery();
                        if (res > 0)
                        {
                            MessageBox.Show("تم الحفظ");
                            FreeControl(ctrls);
                        }

                    });
                else MessageBox.Show("هذا الرقم العسكري تم ادخاله من قبل");
            }
            else MessageBox.Show("يجب ادخال كافة البيانات ");

        }


        public bool CheckIfExist()
        {
            var query = String.Format(@"select count(*) from t_examiners where sold_id='{0}'", txtSold_id.Text);
            var exists = false;
            cmd.GetCMDConnection(query, _cmd =>
            {
                var res = _cmd.ExecuteScalar();
                if (int.Parse(res.ToString()) > 0) exists = true;
            });
            return exists;
        }
        public bool CheckValidations(List<Object> sender)
        {
            foreach (var item in sender)
            {
                var _item = (TextBox)item;
                if (_item.Text == "") return false;
            }
            return true;
        }

        public void FreeControl(List<Object> sender)
        {
            foreach (var item in sender)
            {
                var _item = (TextBox)item;
                _item.Text = "";
            }
        }

        private void txtSold_id_Leave(object sender, EventArgs e)
        {
            var sold_id = txtSold_id.Text;
            txtYear.Text = sold_id.Substring(0, 4);

            currQualification = fcmb.RTQualifications().FirstOrDefault(q => q.Value == int.Parse(sold_id.Substring(5, 1)));

            txtQualification.Text = currQualification.Text;

            var rg_id = int.Parse(sold_id.Substring(4, 1));
            GetGoverns(drpGoverns, rg_id);
        }
    }
}
