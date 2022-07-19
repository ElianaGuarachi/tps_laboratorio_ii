using Entidades.Excepciones;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class DataBaseCliente
    {
        private static SqlConnection connection;
        private static string stringConnection;

        static DataBaseCliente()
        {
            DataBaseCliente.stringConnection = "Server=.;Database=RecuperatorioTP4;Trusted_Connection=True;";            
        }

        public static List<Cliente> ObtenerLista()
        {
            List<Cliente> clientes = new List<Cliente>();
            Cliente cliente = null;
            string query = $"SELECT * FROM clientes";
            try
            {
                using (DataBaseCliente.connection = new SqlConnection(stringConnection))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        cliente = new Cliente(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2),
                                        reader.GetString(3), reader.GetString(4), reader.GetString(5));
                        clientes.Add(cliente);
                    }
                    return clientes;
                }
            }
            catch (Exception)
            {
                throw new DataBaseManagerException("No se pudo conectar con la base de datos");
            }
        }               

        public static Cliente ObtenerClientePorDni(int dni)
        {
            Cliente cliente = null;
            string query = $"SELECT * FROM clientes WHERE dni = @dni";
            try
            {
                using (DataBaseCliente.connection = new SqlConnection(stringConnection))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@dni", dni);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        cliente = new Cliente(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2),
                                       reader.GetString(3), reader.GetString(4), reader.GetString(5));
                    }
                    return cliente;
                }
            }
            catch (Exception)
            {
                throw new DataBaseManagerException("No se pudo conectar con la base de datos");
            }
        }

        public static void Alta(Cliente cliente)
        {
            string query = $"insert into clientes(dni, nombre, apellido, telefono, direccion) values(@dni, @nombre, @apellido, @telefono, @direccion)";
            try
            {
                using (DataBaseCliente.connection = new SqlConnection(stringConnection))
                {
                    DataBaseCliente.connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@dni", cliente.Dni);
                    command.Parameters.AddWithValue("@nombre", cliente.Nombre);
                    command.Parameters.AddWithValue("@apellido", cliente.Apellido);
                    command.Parameters.AddWithValue("@telefono", cliente.Telefono);
                    command.Parameters.AddWithValue("@direccion", cliente.Direccion);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw new DataBaseManagerException("No se pudo conectar con la base de datos");
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="cliente"></param>
        /// <exception cref="DataBaseManagerException"></exception>
        public static void Modificar(Cliente cliente)
        {
            string query = $"update clientes set telefono=@telefono where dni=@dni;" +
                           $"update clientes set direccion=@direccion where dni=@dni";
            try
            {
                using (SqlConnection connection = new SqlConnection(DataBaseCliente.stringConnection))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@dni", cliente.Dni);
                    command.Parameters.AddWithValue("@telefono", cliente.Telefono);
                    command.Parameters.AddWithValue("@direccion", cliente.Direccion);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw new DataBaseManagerException("Error en la conexion con la base de datos");
            }
        }        

        public static void Eliminar(Cliente cliente)
        {
            string query = $"delete from clientes where dni=@dni";
            try
            {
                using (SqlConnection connection = new SqlConnection(DataBaseCliente.stringConnection))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@dni", cliente.Dni);
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
