using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;
using System.Xml.Serialization;
using System.Xml;

namespace Entidades
{
    public static class Serializadora
    {
        private static string rutaBase;

        static Serializadora()
        {
            Serializadora.rutaBase = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

        public static bool EscribirArchivoTxt(string ruta, Cliente contenido, bool append)
        {            
            try
            {
                using (StreamWriter streamWriter = new StreamWriter($"{Serializadora.rutaBase}\\{ruta}"))
                {
                    streamWriter.WriteLine(contenido);
                    return true;
                }                
            }
            catch (Exception ex)
            {
                throw new ArchivoException("Error al escribir", ex);
            }           
        }

        public static void Serializar_XmlTextWriter(string nombreArchivo, Cliente cliente)
        {
            using (XmlTextWriter xmlTextWriter = new XmlTextWriter($"{Serializadora.rutaBase}{nombreArchivo}", Encoding.UTF8))
            {
                XmlSerializer xml = new XmlSerializer(typeof(Cliente));
                xmlTextWriter.Formatting = Formatting.Indented;
                xml.Serialize(xmlTextWriter, cliente);
            }
        }

        public static Cliente Deserializar_StreamReader(string nombreArchivo)
        {
            using (StreamReader streamReader = new StreamReader($"{Serializadora.rutaBase}{nombreArchivo}"))
            {
                XmlSerializer xml = new XmlSerializer(typeof(Cliente));
                Cliente cliente = xml.Deserialize(streamReader) as Cliente;
                return cliente;
            }
        }

        public static Cliente Deserializar_XmlTextReader(string nombreArchivo)
        {
            using (XmlTextReader xmlReader = new XmlTextReader($"{Serializadora.rutaBase}{nombreArchivo}"))
            {
                XmlSerializer xml = new XmlSerializer(typeof(Cliente));
                Cliente cliente= xml.Deserialize(xmlReader) as Cliente;
                return cliente;
            }
        }


    }
}
