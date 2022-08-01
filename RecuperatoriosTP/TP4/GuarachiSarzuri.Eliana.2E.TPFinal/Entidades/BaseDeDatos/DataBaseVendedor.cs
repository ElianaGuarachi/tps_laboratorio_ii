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
            DataBaseVendedor.stringConnection = "Server=.;Database=SISTEMA_DE_VENTA;Trusted_Connection=True;";
        }

        /// <summary>
        /// Metodo estatico que obtiene la lista de vendedores de la base de datos
        /// </summary>
        /// <returns>La lista de vendedores</returns>
        /// <exception cref="DataBaseManagerException">Si hubo un error en la conexion</exception>
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
                        int _id = reader.GetInt32(0);
                        int _dni = reader.GetInt32(1);
                        string _nombre = reader.GetString(2);
                        string _apellido = reader.GetString(3);
                        double _sueldo = reader.GetDouble(4);
                        bool _activo = reader.GetBoolean(5);
                        string _alta = reader.GetString(6);
                        string _baja;
                        if (reader.IsDBNull(7))
                        {
                            _baja = "";
                        }
                        else
                        {
                            _baja = reader.GetString(7);
                        }

                        vendedor = new Vendedor(_id, _dni, _nombre, _apellido, _sueldo, _activo, _alta, _baja);
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

        /// <summary>
        /// Metodo estatico que permite buscar un vendedor por el DNI
        /// </summary>
        /// <param name="dni">Parametro de tipo entero que representa el DNI</param>
        /// <returns>EL vendedor si lo encontro o null si no esta en la base de datos</returns>
        /// <exception cref="DataBaseManagerException">Si hubo un error en la conexion</exception>
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
                        int _id = reader.GetInt32(0);
                        int _dni = reader.GetInt32(1);
                        string _nombre = reader.GetString(2);
                        string _apellido = reader.GetString(3);
                        double _sueldo = reader.GetDouble(4);
                        bool _activo = reader.GetBoolean(5);
                        string _alta = reader.GetString(6);                        
                        string _baja = reader.IsDBNull(7) ? "" : reader.GetString(7);

                        vendedor = new Vendedor(_id,_dni,_nombre,_apellido, _sueldo, _activo,_alta,_baja);
                    }
                    return vendedor;
                }
            }
            catch (Exception)
            {
                throw new DataBaseManagerException("No se pudo conectar con la base de datos");
            }
        }

        /// <summary>
        /// Metodo estatico que permite realizar el alta de un vendedor nuevo
        /// </summary>
        /// <param name="vendedor">Parametro de tipo Vendedor</param>
        /// <exception cref="DataBaseManagerException">Si hubo un error en la conexion</exception>
        public static void Alta(Vendedor vendedor)
        {
            string query = $"insert into vendedores(dni, nombre, apellido, sueldo, esta_activo, fecha_alta,fecha_baja) " +
                $"values(@dni, @nombre, @apellido, @sueldo, @es_activo, @fecha_alta, @fecha_baja)";
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
                    command.Parameters.AddWithValue("@es_activo", vendedor.EsActivo);
                    command.Parameters.AddWithValue("@fecha_alta", vendedor.FechaAlta);
                    command.Parameters.AddWithValue("@fecha_baja", vendedor.FechaBaja);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw new DataBaseManagerException("No se pudo conectar con la base de datos");
            }
        }

        /// <summary>
        /// Baja logica de un vendedor, se registra la fecha que se dio de baja al vendedor
        /// </summary>
        /// <param name="vendedor">Parametro de tipo Vendedor</param>
        /// <exception cref="DataBaseManagerException">Si hubo un error en la conexion</exception>
        public static void DarDeBaja(Vendedor vendedor)
        {
            string query = $"update vendedores set esta_activo=@activo, fecha_baja=@baja where dni=@dni";
            try
            {
                using (SqlConnection connection = new SqlConnection(DataBaseVendedor.stringConnection))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@dni", vendedor.Dni);
                    command.Parameters.AddWithValue("@activo", vendedor.EsActivo);
                    command.Parameters.AddWithValue("@baja", vendedor.FechaBaja);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw new DataBaseManagerException("Error en la conexion con la base de datos");
            }
        }

        /// <summary>
        /// Elimina la informacion de un vendedor de la base de datos
        /// </summary>
        /// <param name="vendedor">Parametro de tipo Vendedor</param>
        /// /// <exception cref="DataBaseManagerException">Si hubo un error en la conexion</exception>
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
