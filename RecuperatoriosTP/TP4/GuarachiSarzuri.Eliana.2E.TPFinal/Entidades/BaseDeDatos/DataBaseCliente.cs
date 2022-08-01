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
        private static string stringConnection;
        private static SqlConnection connection;
        private static SqlCommand comando;

        static DataBaseCliente()
        {
            stringConnection = "Server=.;Database=SISTEMA_DE_VENTA;Trusted_Connection=True;";
            connection = new SqlConnection(stringConnection);
            comando = new SqlCommand();
            comando.Connection = connection;
            comando.CommandType = System.Data.CommandType.Text;
        }

        /// <summary>
        /// Metodo que se encarga de obtener la lista de todos los clientes desde la base de datos
        /// </summary>
        /// <returns>la lista de clientes o null si no puedo cargar</returns>
        /// /// <exception cref="DataBaseManagerException">si hubo un error en la conexion a la base de datos</exception>
        public static List<Cliente> ObtenerLista()
        {
            List<Cliente> clientes = new List<Cliente>();
            Cliente cliente = null;
            try
            {
                connection.Open();
                comando.CommandText = "SELECT * FROM clientes";
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    cliente = new Cliente(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2),
                                    reader.GetString(3), reader.GetString(4), reader.GetString(5));
                    clientes.Add(cliente);
                }                
            }
            catch (Exception)
            {
                throw new DataBaseManagerException("No se pudo conectar con la base de datos");
            }
            finally
            {
                connection.Close();
            }
            return clientes;
        }

        /// <summary>
        /// Obtiene la informacion de un cliente por el DNI
        /// </summary>
        /// <param name="dni">Parametro de tipo entero que representa el DNI</param>
        /// <returns>La informacion del cliente encontrado, o null si no lo encontro o hubo un error</returns>
        /// /// <exception cref="DataBaseManagerException">si hubo un error en la conexion a la base de datos</exception>
        public static Cliente ObtenerClientePorDni(int dni)
        {
            Cliente cliente = null;
            try
            {
                comando.Parameters.Clear();
                connection.Open();
                comando.CommandText = "SELECT* FROM clientes WHERE dni = @dni";
                comando.Parameters.AddWithValue("@dni", dni);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    cliente = new Cliente(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2),
                                   reader.GetString(3), reader.GetString(4), reader.GetString(5));
                }                
            }
            catch (Exception)
            {
                throw new DataBaseManagerException("No se pudo conectar con la base de datos");
            }
            finally
            {
                connection.Close();
            }
            return cliente;
        }

        /// <summary>
        /// Metodo que realiza el alta de un cliente y guarda su informacion en la base de datos
        /// </summary>
        /// <param name="cliente">Parametro de tipo Cliente</param>
        /// /// <exception cref="DataBaseManagerException">si hubo un error en la conexion a la base de datos</exception>
        public static void Alta(Cliente cliente)
        {
            try
            {
                comando.Parameters.Clear();
                connection.Open();
                comando.CommandText = "insert into clientes(dni, nombre, apellido, telefono, direccion) values(@dni, @nombre, @apellido, @telefono, @direccion)";
                comando.Parameters.AddWithValue("@dni", cliente.Dni);
                comando.Parameters.AddWithValue("@nombre", cliente.Nombre);
                comando.Parameters.AddWithValue("@apellido", cliente.Apellido);
                comando.Parameters.AddWithValue("@telefono", cliente.Telefono);
                comando.Parameters.AddWithValue("@direccion", cliente.Direccion);
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new DataBaseManagerException("No se pudo conectar con la base de datos");
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Metodo que realiza una modificacion sobre la informacion de un cliente en la base de datos
        /// </summary>
        /// <param name="cliente">Parametro de tipo cliente</param>
        /// <exception cref="DataBaseManagerException">si hubo un error en la conexion a la base de datos</exception>
        public static void Modificar(Cliente cliente)
        {
            try
            {
                comando.Parameters.Clear();
                connection.Open();
                comando.CommandText = "update clientes set telefono=@telefono, direccion=@direccion where dni=@dni;";
                comando.Parameters.AddWithValue("@dni", cliente.Dni);
                comando.Parameters.AddWithValue("@telefono", cliente.Telefono);
                comando.Parameters.AddWithValue("@direccion", cliente.Direccion);
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new DataBaseManagerException("Error en la conexion con la base de datos");
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Elimina la informacion de un cliente en la base de datos
        /// </summary>
        /// <param name="cliente">Parametro de tipo Cliente</param>
        /// /// <exception cref="DataBaseManagerException">si hubo un error en la conexion a la base de datos</exception>
        public static void Eliminar(Cliente cliente)
        {
            try
            {
                comando.Parameters.Clear();
                connection.Open();
                comando.CommandText = "delete from clientes where dni=@dni";
                comando.Parameters.AddWithValue("@dni", cliente.Dni);
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new DataBaseManagerException("Error en la conexion con la base de datos");
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
