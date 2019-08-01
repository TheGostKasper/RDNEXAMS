using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatesExam
{
    public class Results
    {
        public string Sold_id { get; set; }
        public int Exam_id { get; set; }
        public string Exam_name { get; set; }
        public int Full_mark { get; set; }
        public int Exam_duration { get; set; }
        public List<Answers> ListAnswers { get; set; }

        public string Barcode { get; set; }
    }
}
