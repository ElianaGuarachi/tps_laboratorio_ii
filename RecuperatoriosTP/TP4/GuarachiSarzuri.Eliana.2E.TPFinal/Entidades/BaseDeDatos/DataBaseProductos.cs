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
            DataBaseProductos.stringConnection = "Server=.;Database=SISTEMA_DE_VENTA;Trusted_Connection=True;";
        }

        /// <summary>
        /// Obtiene la lista de productos que se encuentra en la base de datos
        /// </summary>
        /// <returns>La lista de productos</returns>
        /// <exception cref="DataBaseManagerException">Si hubo un error en la conexion</exception>
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

        /// <summary>
        /// Actualiza el stock a traves del id del producto
        /// </summary>
        /// <param name="producto">Parametro de tipo Producto</param>
        /// <exception cref="DataBaseManagerException">Si hubo un error en la conexion</exception>
        public static void ActualizarStock(Producto producto)
        {
            string query = "update productos set stock=@stock where id_productos=@id;";
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

        /// <summary>
        /// Metodo estatico que guarda el detalle de un producto vendido
        /// </summary>
        /// <param name="detalleVenta">Parametro de tipo DetalleVenta</param>
        /// <exception cref="DataBaseManagerException">Si hubo un error en la conexion</exception>
        public static void AgregarDetalleDeProducto(DetalleVenta detalleVenta)
        {
            string query = "insert into detalle_venta (id_venta, producto, precio_venta, cantidad, subtotal, fecha_registro) " +
                $"values(@id, @producto, @precio, @cantidad, @subtotal, @fecha)";
            try
            {
                using (DataBaseProductos.connection = new SqlConnection(stringConnection))
                {
                    DataBaseProductos.connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", detalleVenta.IdVenta);
                    command.Parameters.AddWithValue("@producto", detalleVenta.Producto);
                    command.Parameters.AddWithValue("@precio", detalleVenta.PrecioVenta);
                    command.Parameters.AddWithValue("@cantidad", detalleVenta.Cantidad);
                    command.Parameters.AddWithValue("@subtotal", detalleVenta.Subtotal);
                    command.Parameters.AddWithValue("@fecha", detalleVenta.FechaRegistro);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw new DataBaseManagerException("No se pudo conectar con la base de datos");
            }
        }

        /// <summary>
        /// Guarda la informacion de una venta realizada
        /// </summary>
        /// <param name="venta"></param>
        /// <exception cref="DataBaseManagerException">Si hubo un error en la conexion</exception>
        public static void AgregarVenta(Venta venta)
        {
            string query = "insert into ventas (vendedor, comprador, precio_total, pago_realizado, fecha_registro) " +
                $"values(@vendedor, @comprador, @precioTotal, @pagoRealizado, @fecha)";
            try
            {
                using (DataBaseProductos.connection = new SqlConnection(stringConnection))
                {
                    DataBaseProductos.connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@vendedor", venta.Vendedor);
                    command.Parameters.AddWithValue("@comprador", venta.Comprador);
                    command.Parameters.AddWithValue("@precioTotal", venta.PrecioTotal);
                    command.Parameters.AddWithValue("@pagoRealizado", venta.PagoRealizado);
                    command.Parameters.AddWithValue("@fecha", venta.FechaRegistro);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw new DataBaseManagerException("No se pudo conectar con la base de datos");
            }
        }

        /// <summary>
        /// Obtiene el ID de una venta guardada en la base de datos a partir de la informacion del comprador y el precio total de la venta
        /// </summary>
        /// <param name="venta">Parametro de tipo Venta</param>
        /// <returns>Ek id de la Venta</returns>
        /// <exception cref="DataBaseManagerException">Si hubo un error en la conexion</exception>
        public static int ObtenerIdVenta(Venta venta)
        {
            int idVenta = 0;
            string query = "SELECT ID_VENTAS FROM VENTAS WHERE COMPRADOR = @COMPRADOR AND PRECIO_TOTAL = @PRECIO";
            try
            {
                using (DataBaseProductos.connection = new SqlConnection(stringConnection))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@comprador", venta.Comprador);
                    command.Parameters.AddWithValue("@precio", venta.PrecioTotal);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        idVenta = reader.GetInt32(0);
                    }
                    return idVenta;
                }
            }
            catch (Exception)
            {
                throw new Exception("No se pudo obtener el id de la venta");
            }
        }

        /// <summary>
        /// Obtiene la lista de todas las ventas registradas en la base de datos
        /// </summary>
        /// <returns>La lista de las ventas</returns>
        /// <exception cref="DataBaseManagerException">Si hubo un error en la conexion</exception>
        public static List<Venta> ObtenerListaVentas()
        {
            List<Venta> ventas = new List<Venta>();
            string query = "SELECT * FROM ventas";
            try
            {
                using (DataBaseProductos.connection = new SqlConnection(stringConnection))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Venta venta = new Venta(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
                            reader.GetDouble(3), reader.GetBoolean(4), reader.GetString(5));
                        ventas.Add(venta);
                    }
                    return ventas;
                }
            }
            catch (Exception)
            {
                throw new Exception("No se cargo la lista de ventas");
            }
        }

        /// <summary>
        /// Busca la lista de detalles de venta que se registraron en una venta a partir de su id
        /// </summary>
        /// <param name="idVenta">Parametro de tipo Venta</param>
        /// <returns>La lista de los detalles de venta</returns>
        /// <exception cref="DataBaseManagerException">Si hubo un error en la conexion</exception>
        public static List<DetalleVenta> ObtenerDetalleVentaPorIdVenta(int idVenta)
        {
            List<DetalleVenta> detalles = new List<DetalleVenta>();
            string query = $"SELECT ID_DETALLE_VENTA, ID_VENTA, PRODUCTO, PRECIO_VENTA, CANTIDAD, " +
                "SUBTOTAL, FECHA_REGISTRO FROM DETALLE_VENTA where id_venta = @idVenta";
            try
            {
                using (DataBaseProductos.connection = new SqlConnection(stringConnection))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@idVenta", idVenta);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        DetalleVenta detalleVenta = new DetalleVenta(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2),
                            reader.GetDouble(3), reader.GetInt32(4), reader.GetDouble(5), reader.GetString(6));
                        detalles.Add(detalleVenta);
                    }
                    return detalles;
                }
            }
            catch (Exception)
            {
                throw new Exception($"No se cargo el detalle de la venta {idVenta}");
            }
        }
    }
}
