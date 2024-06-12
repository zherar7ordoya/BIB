using System.Text;
using System.Xml.Serialization;

namespace XmlSerialization;

/// <summary>
/// Using the [Xml*] attributes
/// </summary>
 
  [XmlRoot(ElementName = "Product",
    Namespace = "http://www.pdsa.com")]
  public partial class ProductWithAttributes
  {
    [XmlAttribute("ProductId")]
    public int ProductID { get; set; }
    [XmlElement("ProductName")]
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// This property will not be written out
    /// </summary>
    [XmlIgnore]
    public string ProductDescription { get; set; } = string.Empty;
    public string ProductNumber { get; set; } = string.Empty;
    [XmlElement(IsNullable = true)]
    public string? Color { get; set; } = string.Empty;
    /// <summary>
    /// If Size is null, the XML element will still appear
    /// </summary>
    //[XmlElement(IsNullable = true)]
    public string? Size { get; set; } = string.Empty;
    public decimal StandardCost { get; set; }
    public decimal ListPrice { get; set; }

    #region Static Method to Create a Mock Product
    public static ProductWithAttributes CreateMock()
    {
      // Create an Object
      return new() {
        ProductID = 999,
        Name = "Mock Product",
        ProductNumber = "MOCK-001",
        Color = "White",
        StandardCost = 10,
        ListPrice = 20,
        Size = "Medium"
      };
    }
    #endregion

  #region ToString Override 
  public override string ToString()
  {
    StringBuilder sb = new(1024);

    sb.AppendLine($"{Name}  ID: {ProductID}");
    sb.AppendLine($"   Color: {Color ?? "n/a"}   Size: {Size ?? "n/a"}");
    sb.AppendLine($"   Cost: {StandardCost:c}   Price: {ListPrice:c}");

    return sb.ToString();
  }
  #endregion
}
