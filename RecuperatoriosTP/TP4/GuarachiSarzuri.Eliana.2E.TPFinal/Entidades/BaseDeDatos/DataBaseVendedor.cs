using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Entidades.Excepciones;

namespace Entidades.BaseDeDatos
{
    public static class DataBaseVendedor
    {
        private static SqlConnection connection;
        private static string stringConnection;

        static DataBaseVendedor()
        {
            DataBaseVendedor.stringConnection = "Server=.;Database=RecuperatorioTP4;Trusted_Connection=True;";
        }

        public static List<Vendedor> ObtenerLista()
        {
            List<Vendedor> vendedores = new List<Vendedor>();
            Vendedor vendedor = null;
            string query = $"SELECT * FROM vendedores";
            try
            {
                using (DataBaseVendedor.connection = new SqlConnection(stringConnection))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        vendedor = new Vendedor(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2),
                                        reader.GetString(3), reader.GetDouble(4));
                        vendedores.Add(vendedor);
                    }
                    return vendedores;
                }
            }
            catch (Exception)
            {
                throw new DataBaseManagerException("No se pudo conectar con la base de datos");
            }
        }

        public static Vendedor ObtenerVendedorPorDni(int dni)
        {
            Vendedor vendedor = null;
            string query = $"SELECT * FROM vendedores WHERE dni = @dni";
            try
            {
                using (DataBaseVendedor.connection = new SqlConnection(stringConnection))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@dni", dni);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        vendedor = new Vendedor(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2),
                                       reader.GetString(3), reader.GetDouble(4));
                    }
                    return vendedor;
                }
            }
            catch (Exception)
            {
                throw new DataBaseManagerException("No se pudo conectar con la base de datos");
            }
        }

        public static void Alta(Vendedor vendedor)
        {
            string query = $"insert into vendedores(dni, nombre, apellido, sueldo) values(@dni, @nombre, @apellido, @sueldo)";
            try
            {
                using (DataBaseVendedor.connection = new SqlConnection(stringConnection))
                {
                    DataBaseVendedor.connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@dni", vendedor.Dni);
                    command.Parameters.AddWithValue("@nombre", vendedor.Nombre);
                    command.Parameters.AddWithValue("@apellido", vendedor.Apellido);
                    command.Parameters.AddWithValue("@sueldo", vendedor.Sueldo);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw new DataBaseManagerException("No se pudo conectar con la base de datos");
            }
        }

        public static void Modificar(Vendedor vendedor)
        {
            string query = $"update vendedores set sueldo=@sueldo where dni=@dni";
            try
            {
                using (SqlConnection connection = new SqlConnection(DataBaseVendedor.stringConnection))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@dni", vendedor.Dni);
                    command.Parameters.AddWithValue("@sueldo", vendedor.Sueldo);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw new DataBaseManagerException("Error en la conexion con la base de datos");
            }
        }


        public static void Eliminar(Vendedor vendedor)
        {
            string query = $"delete from vendedores where dni=@dni";
            try
            {
                using (SqlConnection connection = new SqlConnection(DataBaseVendedor.stringConnection))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@dni", vendedor.Dni);
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
