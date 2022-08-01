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
using Entidades.Excepciones;

namespace Entidades
{
    public static class FileManager
    {         
        private static string path;

        static FileManager()
        {
            path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Sistema de ventas");
            FileManager.ValidaExistenciaDeDirectorio();
        }

        /// <summary>
        /// Metodo generico que se encargara de seriazar o guardar un archivo
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento">Parametro generico de tipo clase</param>
        /// <param name="nombreArchivo">Parametro de tipo string</param>
        /// <exception cref="ArchivoException">Cuando el formato del archivo es incorrecto</exception>
        public static void GuardarArchivosGenericos<T>(T elemento, string nombreArchivo)
            where T: class
        {
            using (StreamWriter writer = new StreamWriter(Path.Combine(path,nombreArchivo)))
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

        /// <summary>
        /// Metodo generico que deserializara archivho json o xml
        /// </summary>
        /// <typeparam name="T">Parametro generico de tipo clase</typeparam>
        /// <param name="nombreArchivo">Parametro de tipo string</param>
        /// <returns></returns>
        public static T DeserializarArchivosGenericos<T>(string nombreArchivo)
            where T: class
        {
            using (StreamReader streamReader = new StreamReader(Path.Combine(path, nombreArchivo)))
            {
                switch (Path.GetExtension(nombreArchivo))
                {
                    case ".json":
                        string objetoJson = File.ReadAllText(Path.Combine(path, nombreArchivo));
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

        /// <summary>
        /// Metodo que evalua si un directorio existe, si no existe lo crea
        /// </summary>
        private static void ValidaExistenciaDeDirectorio()
        {
            bool resultado = Directory.Exists(path);
            if (resultado == false)
            {
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch (Exception ex)
                {
                    throw new FileSerializerException("Error al crear el directorio", ex);
                }

            }
        }

    }
}
