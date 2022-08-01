using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using Excepciones;

namespace Testeos
{
    [TestClass]
    public class PruebasExcepciones
    {
        [TestMethod]
        [ExpectedException(typeof(ParametrosVaciosException))]
        public void Propiedad_CuandoCompletoLaPropiedad_DeberiaLanzarParametrosVaciosException()
        {
            // Arrange
            Cliente cliente = new Cliente(38177868, "Sergio", "Median", "11110", "Mitre 750");

            // Act
            cliente.Telefono = "";

            // Assert
        }
    }
}
