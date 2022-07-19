using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;
using System.Xml.Serialization;
using System.Xml;
using System.Text.Json;

namespace Entidades
{
    public static class Serializadora
    {
        private static string rutaBase;

        static Serializadora()
        {
            Serializadora.rutaBase = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

        public static void GuardarArchivosGenericos<T>(T elemento, string nombreArchivo)
            where T: class
        {
            using (StreamWriter writer = new StreamWriter($"{Serializadora.rutaBase}\\{nombreArchivo}"))
            {              
                switch (Path.GetExtension(nombreArchivo))
                {
                    case ".json":
                        JsonSerializerOptions options = new JsonSerializerOptions();
                        options.WriteIndented = true;
                        writer.WriteLine(JsonSerializer.Serialize(elemento, typeof(T), options));
                        break;
                    case ".txt":
                        writer.WriteLine(elemento);
                        break;
                    case ".xml":
                        XmlSerializer xml = new XmlSerializer(typeof(T));
                        xml.Serialize(writer, elemento);
                        break;
                    default:
                        throw new ArchivoException("Extension no permitida");
                }
            }
        }

        public static T DeserializarArchivosGenericos<T>(string nombreArchivo)
            where T: class
        {
            using (StreamReader streamReader = new StreamReader($"{Serializadora.rutaBase}\\{nombreArchivo}"))
            {
                switch (Path.GetExtension(nombreArchivo))
                {
                    case ".json":
                        string objetoJson = File.ReadAllText(nombreArchivo);
                        T objeto = JsonSerializer.Deserialize<T>(objetoJson);
                        return objeto;

                    case ".xml":
                        XmlSerializer xml = new XmlSerializer(typeof(T));
                        T objetoXml = xml.Deserialize(streamReader) as T;
                        return objetoXml;

                    default:
                        throw new ArchivoException("Extension no permitida");
                }
            }
        }

    }
}
