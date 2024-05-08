using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace Experimental
{
    internal static class XmlDAL
    {
        public static string MapearDesdeObjetoHaciaXml<T>(this T entity)
        {
            return MapearDesdeObjetoHaciaXml<T>(entity, null);
        }

        public static string MapearDesdeObjetoHaciaXml<T>(this T entity, XmlSerializerNamespaces ns)
        {
            string ret = string.Empty;

            if (entity != null)
            {
                // Create XML Serializer
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                // Create a StringWriter to write into
                StringWriter sw = new StringWriter();
                // Create a XmlWriterSettings object
                // and add option to Indent
                XmlWriterSettings options = new XmlWriterSettings()
                {
                    Indent = true
                };

                // Use an XmlWriter to format the XML
                XmlWriter xw = XmlWriter.Create(sw, options);
                // Serialize the object
                serializer.Serialize(xw, entity, ns);
                xw.Dispose();

                // Get the XML
                ret = sw.ToString();

                sw.Dispose();
            }

            return ret;
        }


        public static T MapearDesdeXmlHaciaObjeto<T>(this T _, string xml) where T : class
        {
            var ret = default(T);

            if (!string.IsNullOrEmpty(xml))
            {
                // Create XML Serializer
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                // Create a StringReader with the XML
                StringReader sr = new StringReader(xml);
                // Deserialize the XML into a C# object
                ret = (T)serializer.Deserialize(sr);
                // Cerrar el lector manualmente
                sr.Dispose();

                /*
                 EQUIVALENTE:
                    using (var sr = new StringReader(xml))
                    {                   
                        // El código que utiliza sr va aquí
                    }
                 */
            }

            return ret;
        }

    }
}
