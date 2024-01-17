using DataLayer.Models;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class ProductRepository
    {
        private string connString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=vezbanjekolok;Integrated Security=True;";
        public List<Product> GetProducts()
        {
            
            using (SqlConnection konekcija = new SqlConnection(connString)) 
            {
                konekcija.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = konekcija;
                command.CommandText = "SELECT * FROM PRODUCTS";
                List<Product> products = new List<Product>();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Product product
                        = new Product();
                    product.Id = reader.GetInt32(0);
                    product.Name = reader.GetString(1);
                    product.ExpiaryDate = reader.GetDateTime(2);
                    products.Add(product);
                }
                return products;
            }
            
        }
    
    }
}
