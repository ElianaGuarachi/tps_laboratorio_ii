using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace Testeos
{
    [TestClass]
    public class PruebasDeserializar
    {
        [TestMethod]
        public void DeserializarArchivosGenericos_CuandoLeeUnArchivoJson_DeberiaRetornarElClienteSerializado()
        {
            // Arrange
            Persona cliente = new Cliente(38177868, "Carlos", "Guzman", "11111111", "Mitre 750");

            // Act
            FileManager.GuardarArchivosGenericos(cliente, "cliente.json");

            // Assert
            Cliente clienteDeserializado = FileManager.DeserializarArchivosGenericos<Cliente>("cliente.json");
            Assert.AreEqual(cliente.Dni, clienteDeserializado.Dni);
        }

        [TestMethod]
        public void DeserializarArchivosGenericos_CuandoLeeUnArchivoXml_DeberiaRetornarElVendedorSerializado()
        {
            // Arrange
            Persona vendedor = new Vendedor(38177868, "Carlos", "Zarate", 145000.45, true, "26/04/2022", "");

            // Act
            FileManager.GuardarArchivosGenericos(vendedor, "vendedor.xml");

            // Assert
            Persona vendedorDeserializado = FileManager.DeserializarArchivosGenericos<Persona>("vendedor.xml");
            Assert.AreEqual(vendedor.Nombre, vendedorDeserializado.Nombre);
        }
    }
}
