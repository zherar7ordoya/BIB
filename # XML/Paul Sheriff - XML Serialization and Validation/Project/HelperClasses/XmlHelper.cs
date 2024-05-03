using System.Globalization;
using System.Xml.Linq;

namespace XmlSerialization;

public static class XmlHelper
{
  public static T GetAs<T>(this XElement elem, string name) where T : notnull
  {
    var ret = default(T);

    if (elem != null) {
      XElement? current = elem.Element(name);
      if (current != null) {
        string value = current.Value;
        // Cast to Return Data Type
        // NOTE: ChangeType can not cast to a Nullable type
        if (value != null) {
          ret = (T)Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture);
        }
      }
    }

    return ret;
  }

  public static T GetAttrAs<T>(this XElement elem, string name) where T : notnull
  {
    var ret = default(T);

    if (elem != null) {
      XAttribute? current = elem.Attribute(name);
      if (current != null) {
        string value = current.Value;
        // Cast to Return Data Type
        // NOTE: ChangeType can not cast to a Nullable type
        if (value != null) {
          ret = (T)Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture);
        }
      }
    }

    return ret;
  }

  public static void UpdateElement(this XElement elem, string name, object value)
  {
    if (elem != null) {
      XElement? current = elem.Element(name);
      if (current != null) {
        current.Value = (string)value;
      }
    }
  }
}
