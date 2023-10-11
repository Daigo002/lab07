using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace Data
{
    public class DProduct
    {
        public static string connectionString = "Data Source=LAB1504-10\\SQLEXPRESS;Initial Catalog=FacturaEj;User ID=usertec;Password=tecsup123";
        public List<Product> Get()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Abrir la conexión
                connection.Open();

                // Consulta SQL para seleccionar datos
                string query = "ListarProductos";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Verificar si hay filas
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                // Leer los datos de cada fila
                                products.Add(new Product
                                {
                                    Product_id = (int)reader["product_id"],
                                    Name = reader["name"].ToString(),
                                    Price = reader["price"].ToString(),
                                    Stock = (int)reader["stock"],
                                });

                            }
                        }
                    }
                }

                // Cerrar la conexión
                connection.Close();

            }
            return products;
        }
    }
}