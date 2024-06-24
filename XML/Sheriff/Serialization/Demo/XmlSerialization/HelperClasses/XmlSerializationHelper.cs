using System.Xml;
using System.Xml.Serialization;

namespace XmlSerialization;

/// <summary>
/// Extension methods to 
/// serialize C# objects to XML and
/// deserialize XML into to C# objects
/// </summary>
public static class XmlSerializerHelper
{
    #region Serialize<T> Method
    public static string MapearHaciaXml<T>(this T entity)
    {
        return MapearHaciaXml<T>(entity, null);
    }

    public static string MapearHaciaXml<T>(this T entity, XmlSerializerNamespaces? ns)
    {
        string ret = string.Empty;

        if (entity != null)
        {
            // Create XML Serializer
            XmlSerializer serializer = new(typeof(T));
            // Create a StringWriter to write into
            using StringWriter sw = new();
            // Create a XmlWriterSettings object
            // and add option to Indent
            XmlWriterSettings options = new()
            {
                Indent = true
            };

            // Use an XmlWriter to format the XML
            using XmlWriter xw = XmlWriter.Create(sw, options);
            // Serialize the object
            serializer.Serialize(xw, entity, ns);
            // Get the XML
            ret = sw.ToString();
        }

        return ret;
    }
    #endregion

    #region Deserialize<T> Method
    public static T? Deserialize<T>(this T _, string xml) where T : class
    {
        var ret = default(T);

        if (!string.IsNullOrEmpty(xml))
        {
            // Create XML Serializer
            XmlSerializer serializer = new(typeof(T));
            // Create a StringReader with the XML
            using StringReader sr = new(xml);
            // Deserialize the XML into a C# object
            ret = (T?)serializer.Deserialize(sr);
        }

        return ret;
    }
    #endregion
}