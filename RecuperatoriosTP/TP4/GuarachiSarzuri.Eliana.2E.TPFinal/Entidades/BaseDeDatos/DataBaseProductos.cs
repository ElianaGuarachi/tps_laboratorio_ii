using Entidades.Excepciones;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.BaseDeDatos
{
    public static class DataBaseProductos
    {
        private static SqlConnection connection;
        private static string stringConnection;

        static DataBaseProductos()
        {
            DataBaseProductos.stringConnection = "Server=.;Database=RecuperatorioTP4;Trusted_Connection=True;";
        }

        public static List<Producto> ObtenerLista()
        {
            List<Producto> productos = new List<Producto>();
            string query = "SELECT * FROM productos";
            try
            {
                using (DataBaseProductos.connection = new SqlConnection(stringConnection))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Producto producto = new Producto(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
                            reader.GetInt32(3), reader.GetDouble(4));
                        productos.Add(producto);
                    }
                    return productos;
                }
            }
            catch (Exception)
            {
                throw new Exception("No se cargo la lista de productos");
            }
        }

        public static void ActualizarStock(Producto producto)
        {
            string query = "update productos set stock=@stock where id=@id;";
            try
            {
                using (SqlConnection connection = new SqlConnection(DataBaseProductos.stringConnection))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@stock", producto.Stock);
                    command.Parameters.AddWithValue("@id", producto.Id);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw new DataBaseManagerException("Error en la conexion con la base de datos");
            }
        }



    }
}
