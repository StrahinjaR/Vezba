using DataLayer;
using DataLayer.Shared;

namespace BusinessLayer
{
    public class StudentBusiness
    {
        StudentRepository studentrepo;
        public StudentBusiness(){
               this.studentrepo = new StudentRepository();
                                }

        public List<Student> GetStudents()
        {
            return this.studentrepo.GetStudents();
        }
        public int InsertStudents(Student student)
        {
            return this.studentrepo.InsertStudent(student);
        }
        public List<Student> FiltriraniStudenti()
        {
            return this.studentrepo.GetStudents().Where(s => s.projectpoints>30 && s.testpoints>20 && s.exammark<6).ToList();
        }
        public List<Student> FiltriraniStudentiPoOceni()
        {
            return this.studentrepo.GetStudents().Where(s => s.exammark > 5).ToList();
        }


    }
}
