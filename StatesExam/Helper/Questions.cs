using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace StatesExam
{
    public class Questions
    {
        public int Exam_id { get; set; }
        public string Exam_name { get; set; }
        public string Display_name { get; set; }
        public int Duration { get; set; }
        public int Qus_id { get; set; }
        public string Qus_text { get; set; }
        public byte[] Qus_audio { get; set; }

        public Image Qus_image { get; set; }

        public bool Qus_is_pic { get; set; }
    }
}
