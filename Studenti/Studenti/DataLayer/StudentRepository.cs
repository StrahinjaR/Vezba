using DataLayer.Shared;
using System.Data.SqlClient;

namespace DataLayer
{
    public class StudentRepository
    {
        private string connString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StudentDB;Integrated Security=True;";
        public List<Student> GetStudents()
        {
            using (SqlConnection sqlConnection = new SqlConnection(this.connString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Students";
                SqlDataReader dataReader = sqlCommand.ExecuteReader();

                List<Student> listOfStudents = new List<Student>();

                while (dataReader.Read())
                {
                    Student straja = new Student();
                    straja.id = dataReader.GetInt32(0);
                    straja.studentname = dataReader.GetString(1);
                    straja.indexnumber = dataReader.GetString(2);
                    straja.projectpoints = dataReader.GetInt32(3);
                    straja.testpoints = dataReader.GetInt32(4);
                    straja.exammark = dataReader.GetInt32(5);
                    listOfStudents.Add(straja);
                }

                return listOfStudents;


            }
        }
        public int InsertStudent(Student student)
        {
            using (SqlConnection sqlConnection = new SqlConnection(this.connString))
            {

                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "INSERT INTO Students(StudentName,IndexNumber,ProjectPoints,TestPoints,ExamMark) VALUES(@StudentName,@IndexNumber,@ProjectPoints,@TestPoints,@ExamMark)";
                
                sqlCommand.Parameters.AddWithValue("@StudentName", student.studentname);
                sqlCommand.Parameters.AddWithValue("@IndexNumber", student.indexnumber);
                sqlCommand.Parameters.AddWithValue("@ProjectPoints", student.projectpoints);
                sqlCommand.Parameters.AddWithValue("@TestPoints", student.testpoints);
                sqlCommand.Parameters.AddWithValue("@ExamMark", student.exammark);
                return sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
