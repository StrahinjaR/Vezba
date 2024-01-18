using DataLayer.Shared;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace DataLayer
{
    public class PharmaRepo
    {
        private String connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PharmacyDB;Integrated Security=True;";

        public List<Prescriptions> GetPrescriptions()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Prescriptions";
                SqlDataReader dataReader = sqlCommand.ExecuteReader();

                List<Prescriptions> listOfStudents = new List<Prescriptions>();
                while (dataReader.Read())
                {
                    Prescriptions preskripcija = new Prescriptions();
                    preskripcija.Id = dataReader.GetInt32(0);
                    preskripcija.PatientName = dataReader.GetString(1);
                    preskripcija.Prescribed = dataReader.GetString(2);
                    preskripcija.PrescrpitonDate = dataReader.GetDateTime(3);
                    preskripcija.Price = dataReader.GetDecimal(4);
                    listOfStudents.Add(preskripcija);

                }
                return listOfStudents;
            }
        }
        public int InsertPrescriptions(Prescriptions preskripcija)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "INSERT INTO Prescriptions(PatientName,Prescribed,PrescriptionDate,Price) VALUES(@patient,@prescribed,@prescriptiondate,@price)";

                sqlCommand.Parameters.AddWithValue("@patient", preskripcija.PatientName);
                sqlCommand.Parameters.AddWithValue("@prescribed", preskripcija.Prescribed);
                sqlCommand.Parameters.AddWithValue("@prescriptiondate", preskripcija.PrescrpitonDate);
                sqlCommand.Parameters.AddWithValue("@price", preskripcija.Price);
                return sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
