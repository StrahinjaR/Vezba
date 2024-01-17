using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataLayer.Shared
{
    public class Student

    {
        private int Id;
        private string StudentName;
        private string IndexNumber;

        private int ProjectPoints;

        private int TestPoints;

        private int ExamMark;

        public int id { get => Id; set => Id = value; }
        public string studentname { get => StudentName; set => StudentName = value; }
        public string indexnumber { get => IndexNumber; set => IndexNumber = value; }
        public int projectpoints { get => ProjectPoints; set => ProjectPoints = value; }
        public int testpoints { get => TestPoints; set => TestPoints = value; }
        public int exammark { get => ExamMark; set => ExamMark = value; }

    }
}
