using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StatesExam
{
    public class FillComboValues
    {
        SqlCommands cmd = new SqlCommands();
        public void FillCombo(List<DummyCombo> _list, ComboBox cmx)
        {
            foreach (var item in _list)
            {
                cmx.Items.Add(item);
            }
            cmx.DisplayMember = "Text";
            if (cmx.Items.Count > 0)
                cmx.SelectedIndex = 0;
        }
       

        public void GetQualificationAreas(ComboBox cmx)
        {
            var _list = new List<DummyCombo>(){
                new DummyCombo {Text="عليا",Value=1},
                new DummyCombo {Text="متوسطة",Value=2},
                new DummyCombo {Text="فوق متوسطة",Value=3},
                new DummyCombo {Text="عادة",Value=4},
            };
            FillCombo(_list, cmx);
        }
       
       
        public void GetObsv(ComboBox cmx)
        {
            var _list = new List<DummyCombo>(){
                new DummyCombo {Text="ملحوظ",Value=1},
                new DummyCombo {Text="مقصر",Value=2}
            };
            FillCombo(_list, cmx);
        }
        public void DisplayStages(ComboBox cmx)
        {
            var _list = new List<DummyCombo>(){
                new DummyCombo {Text=String.Concat(DateTime.Now.Year,1),Value=1},
                new DummyCombo {Text=String.Concat(DateTime.Now.Year,2),Value=2},
                new DummyCombo {Text=String.Concat(DateTime.Now.Year,3),Value=3},
                new DummyCombo {Text=String.Concat(DateTime.Now.Year,4),Value=4},
            };
            FillCombo(_list, cmx);
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

        public void GetReaderList(string query, ComboBox tgneedDrp)
        {
            cmd.ReaderCMD(query, _reader =>
            {
                FillFReader(_reader, tgneedDrp);
            });
        }
        public void GetTagneedAreas(DummyCombo p, ComboBox tgneedDrp)
        {
            cmd.ReaderCMD(String.Format(@"select rg_id,rg_name from regions where role_id= {0}", p.Value), _reader =>
            {
                FillFReader(_reader, tgneedDrp);
            });
        }
        public void RTInterviewerOpnion(ComboBox cmx)
        {
            var _list= new List<DummyCombo>(){
                new DummyCombo {Text="لا يعاني من أي مشاكل",Value=1},
                new DummyCombo {Text="عرضه علي فرع الانتقاء والتوجيه",Value=2},
                new DummyCombo {Text="عرضه علي المست من قبل المركز",Value=3}
            };
            FillCombo(_list, cmx);
        }
        public List<DummyCombo> RTQualifications()
        {
            return new List<DummyCombo>(){
                new DummyCombo {Text="عليا",Value=2},
                new DummyCombo {Text="متوسطة",Value=1},
                new DummyCombo {Text="فوق متوسطة",Value=8},
                new DummyCombo {Text="عادة",Value=0},
            };
        }
    }

    public class DummyCombo
    {
        public string Text { get; set; }
        public int Value { get; set; }
    }
}
