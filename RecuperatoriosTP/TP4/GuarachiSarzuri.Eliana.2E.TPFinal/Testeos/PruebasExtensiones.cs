using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System.Collections.Generic;

namespace Testeos
{
    [TestClass]
    public class PruebasExtensiones
    {
        [TestMethod]
        public void Calcular_CuandoCuentaLaCantidadDeVentas_DeberiaRetornarLaCantidadComoString()
        {
            // Arrange
            List<Venta> ventas = new List<Venta>();
            Venta venta1 = new Venta(1, "Omar", "Sergio", 125.25, true, "26/5/2022");
            Venta venta2 = new Venta(2, "Omar", "Sergio", 125.25, true, "26/5/2022");
            Venta venta3 = new Venta(3, "Omar", "Sergio", 125.25, true, "26/5/2022");
            ventas.Add(venta1);
            ventas.Add(venta2);
            ventas.Add(venta3);
            string cantidad = "3";

            // Act
            string valorEsperado = ventas.GetTotalVentas();

            // Assert
            Assert.AreEqual(cantidad, valorEsperado);
        }
    }
}
