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
    public partial class Interview : Form
    {
        SqlCommands cmd = new SqlCommands();
        FillComboValues fcmb = new FillComboValues();
        DummyCombo currQualification = new DummyCombo();
        bool updated = false;

        List<String> _soldTyp = new List<string> { "لائق","لا يوجد","غياب","ترحيل","عرض مست طبي","عرض مست نفسي"};
        public Interview()
        {
            InitializeComponent();
            cmd.Catalog = DBCatalog.DB_Core.ToString();
            Init();
        }
        public void Init()
        {
            fcmb.RTInterviewerOpnion(drpresults);
            fcmb.DisplayStages(drpStage);
            SelectFirstIndex(new List<Control> { drpHosResults, drpSoldSituation, drpConcentrate, drpDrugHistory, drpDrugs, drpFRelationship, drpHosHistory, drpMood, drpPrestiege, drpresults, drpStatus, drpTalkProb });
            drpSoldSituation.DataSource = _soldTyp;
        }

        public bool CheckValidations(List<Object> sender)
        {
            foreach (var item in sender)
            {
                var _item = (Control)item;
                if (_item.Text == "") return false;
            }
            return true;
        }

        public void SelectFirstIndex(List<Control> cmxs)
        {
            foreach (var item in cmxs)
            {
                var cmx = (ComboBox)item;
                if (cmx.Items.Count > 0)
                {
                    cmx.SelectedIndex = 0;
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ctrls = new List<Object> { txtParentWork, txtClinic, txtDrgType, txtFullName, txtNational_id, txtPreJob, txtQualification, txtSold, txtState, txtWeapon, rchComplain };
            if (CheckValidations(ctrls))
            {
                var item = (DummyCombo)drpresults.SelectedItem;
                var query = "";
                if (!updated)
                {
                    query = string.Format(@"insert into interview values('{0}','{1}',{2},'{3}','{4}','{5}',
                                                                         '{6}','{7}','{8}','{9}','{10}',
                                                                         '{11}','{12}','{13}','{14}','{15}',
                                                                         '{16}', '{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}')",
                   txtSold.Text, drpPrestiege.SelectedItem.ToString(), int.Parse(txtage.Value.ToString()),
                   drpConcentrate.SelectedItem.ToString(), drpStatus.SelectedItem.ToString(), txtQualification.Text,
                   txtPreJob.Text, txtWeapon.Text, txtState.Text, txtParentWork.Text, int.Parse(txtBrothers.Value.ToString()),
                   drpFRelationship.SelectedItem.ToString(), rchComplain.Text, drpMood.SelectedItem.ToString(),
                   drpTalkProb.SelectedItem.ToString(), drpHosHistory.SelectedItem.ToString(), txtDrgType.Text,
                   item.Text.ToString(), drpSoldSituation.SelectedItem.ToString(), drpHosResults.SelectedItem.ToString(), txtNational_id.Text, txtClinic.Text, txtDrgType.Text, DateTime.UtcNow.ToShortDateString(), drpStage.Text);
                }
                else
                {
                    query = string.Format(@"update interview set sold_id='{0}', prestiege='{1}',age={2},focused='{3}',
                                            social_status='{4}',qualification='{5}',Job='{6}',weapon='{7}',state='{8}',
                                            parent_job='{9}',brother_no='{10}',family_status='{11}',complain='{12}',
                                            mood='{13}',talk_proplems='{14}',hospital_history='{15}',drugs_exp='{16}',interviewer_opinion='{17}',
                                            solider_situation='{18}',hospital_results='{19}',national_Id='{20}',clinic_history='{21}',drug_types='{22}',stage='{23}' where sold_id='{0}'",
                   txtSold.Text, drpPrestiege.SelectedItem.ToString(), int.Parse(txtage.Value.ToString()),
                   drpConcentrate.SelectedItem.ToString(), drpStatus.SelectedItem.ToString(), txtQualification.Text,
                   txtPreJob.Text, txtWeapon.Text, txtState.Text,
                   txtParentWork.Text, int.Parse(txtBrothers.Value.ToString()),drpFRelationship.SelectedItem.ToString(),
                   rchComplain.Text, drpMood.SelectedItem.ToString(),drpTalkProb.SelectedItem.ToString(),
                   drpHosHistory.SelectedItem.ToString(), txtDrgType.Text, item.Text.ToString(),
                   drpSoldSituation.SelectedItem.ToString(), drpHosResults.SelectedItem.ToString(), txtNational_id.Text,
                   txtClinic.Text, txtDrgType.Text, drpStage.Text);
                }
                cmd.GetCMDConnection(query, _cmd =>
                {
                    var results = _cmd.ExecuteNonQuery();
                    if (results > 0)
                    {
                        MessageBox.Show("تم الحفظ");
                        ClearControls(ctrls);
                    }
                });

            }
            else
            {
                MessageBox.Show("عليك ملئ كافة البيانات ");
            }
        }


        public bool CheckIfExists()
        {

            var query = String.Format(@"select n.*,ex_name ,ex_year+''+ex_stage 'EX_STAGE'  from interview n  inner join t_examiners x on n.sold_id=x.sold_id where n.sold_id='{0}'", txtSrcSold.Text);
            var exists = false;
            cmd.ReaderCMD(query, _reader =>
            {
                if (_reader.HasRows)
                {
                    MessageBox.Show("تم اجراء المقابلة من قبل");
                    while (_reader.Read())
                    {
                        txtSold.Text = _reader.GetValue(1).ToString();
                        drpPrestiege.Text = _reader.GetValue(2).ToString();
                        txtage.Value = int.Parse(_reader.GetValue(3).ToString());
                        drpConcentrate.Text = _reader.GetValue(4).ToString();
                        drpStatus.Text = _reader.GetValue(5).ToString();
                        txtQualification.Text = _reader.GetValue(6).ToString();
                        txtPreJob.Text = _reader.GetValue(7).ToString();
                        txtWeapon.Text = _reader.GetValue(8).ToString();
                        txtState.Text = _reader.GetValue(9).ToString();
                        txtParentWork.Text = _reader.GetValue(10).ToString();
                        txtBrothers.Value = int.Parse(_reader.GetValue(11).ToString());
                        drpFRelationship.Text = _reader.GetValue(12).ToString();
                        rchComplain.Text = _reader.GetValue(13).ToString();
                        drpMood.Text = _reader.GetValue(14).ToString();
                        drpTalkProb.Text = _reader.GetValue(15).ToString();
                        drpHosHistory.Text = _reader.GetValue(16).ToString();
                        drpDrugs.Text = _reader.GetValue(17).ToString();
                        drpresults.Text = _reader.GetValue(18).ToString();

                        drpSoldSituation.Text = _reader.GetValue(19).ToString();
                        drpHosResults.Text = _reader.GetValue(20).ToString();


                        txtNational_id.Text = _reader.GetValue(21).ToString();
                        txtClinic.Text = _reader.GetValue(22).ToString();
                        txtDrgType.Text = _reader.GetValue(23).ToString();

                        txtFullName.Text = _reader.GetValue(26).ToString();
                        drpStage.Text = _reader.GetValue(27).ToString();

                    }
                    _reader.Close();
                    exists = true;
                    updated = true;
                    CheckAvailabilityToEnter(drpHosHistory, txtClinic);
                    CheckAvailabilityToEnter(drpDrugs, txtDrgType);
                }
            });
            return exists;
        }

        private void ClearControls(List<Object> ctrls)
        {
            foreach (var item in ctrls)
            {
                var _item = (Control)item;
                _item.Text = "";
            }
            CheckAvailabilityToEnter(drpHosHistory, txtClinic);
            CheckAvailabilityToEnter(drpDrugs, txtDrgType);
        }

        private void btnSrch_Click(object sender, EventArgs e)
        {
            if (!CheckIfExists())
            {
                var queryBasicInfo = String.Format(@"select ex_barcode,sold_id,ex_name,ex_national_id from t_examiners where sold_id='{0}'", txtSrcSold.Text);
                cmd.ReaderCMD(queryBasicInfo, _reader =>
                {
                    if (_reader.HasRows)
                    {
                        while (_reader.Read())
                        {
                            txtSold.Text = _reader.GetValue(1).ToString();
                            txtFullName.Text = _reader.GetValue(2).ToString();
                            txtNational_id.Text = _reader.GetValue(3).ToString();
                        }
                        updated = false;

                    }
                    else
                    {
                        MessageBox.Show("تأكد من الرقم العسكري وانه تم تسجيله من قبل !!!");
                    }
                });
            }
        }

        private void drpHosHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckAvailabilityToEnter(drpHosHistory, txtClinic);
        }

        private void drpDrugs_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckAvailabilityToEnter(drpDrugs, txtDrgType);
        }

        public void CheckAvailabilityToEnter(ComboBox drp,TextBox txt)
        {
            bool fd = (drp.Text == "لا") ? true : false;
            if (fd)
            {
                txt.Enabled = false;
                txt.Text = "لا";
            }
            else
            {
                txt.Enabled = true;
                //txt.Text = "";
            }
        }
        private void drpresults_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = (DummyCombo)drpresults.SelectedItem;

            if (item.Value == 2)
            {
                drpSoldSituation.Enabled = true;
                drpHosResults.Enabled = false;
                drpSoldSituation.DataSource = _soldTyp;
                drpSoldSituation.Text = "لا يوجد";
            }
            else if (item.Value == 3)
            {
                drpHosResults.Enabled = drpSoldSituation.Enabled = true;
                drpSoldSituation.DataSource =  new List<string> {  "عرض مست طبي", "عرض مست نفسي" };
            }
            else
            {
                drpSoldSituation.Enabled = drpHosResults.Enabled = false;
                drpSoldSituation.DataSource = _soldTyp;
                drpSoldSituation.Text = "لائق";
                drpHosResults.Text = "لا يوجد";
            }
        }
    }
}
