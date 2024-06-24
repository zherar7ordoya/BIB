using System.Xml.Serialization;

namespace XmlSerialization;

[XmlRoot(ElementName = "Products")]
public class ProductCollection
{
  [XmlElement(ElementName = "Product")]
  public Product[] ProductAsArray { get; set; } = Array.Empty<Product>();

  [XmlIgnore]
  public List<Product> Products
  {
    get { return ProductAsArray.ToList(); }
    set { ProductAsArray = value.ToArray(); }
  }
}
