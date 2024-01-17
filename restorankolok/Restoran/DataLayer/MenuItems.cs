using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DataLayer.Shared;
namespace DataLayer
{
    public class MenuItems
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=RestaurantDB;Integrated Security=True;";
        public List<Restorancic> GetRestorans()
        {
            using (SqlConnection sqlConnection = new SqlConnection(this.connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM MenuItems";

                SqlDataReader reader = sqlCommand.ExecuteReader();
                List<Restorancic> restorani = new List<Restorancic>();
                while (reader.Read())
                {
                    Restorancic restoran = new Restorancic();
                    restoran.Id = reader.GetInt32(0);
                    restoran.Name=reader.GetString(1);
                    restoran.Description=reader.GetString(2);
                    restoran.Price=reader.GetDecimal(3);
                    restorani.Add(restoran);

                }
                return restorani;
            };

            
        }
        public int InsertMenuItems(Restorancic resto)
        {
            using (SqlConnection sqlConnection = new SqlConnection(this.connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.Parameters.AddWithValue("@Name", resto.Name);
                sqlCommand.Parameters.AddWithValue("@Description", resto.Description);
                sqlCommand.Parameters.AddWithValue("@Price", resto.Price);
                sqlCommand.CommandText = "INSERT INTO MenuItems(Title, description, price) VALUES(@Name, @Description, @Price)";
                return sqlCommand.ExecuteNonQuery();


            }
        }
    }
}
