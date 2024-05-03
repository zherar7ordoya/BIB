using System.Xml.Serialization;

namespace XmlSerialization;

public class ProductAttributeBased
{
  [XmlAttribute("ProductID")]
  public int ProductID { get; set; }
  [XmlAttribute]
  public string Name { get; set; } = string.Empty;
  [XmlAttribute]
  public string ProductNumber { get; set; } = string.Empty;
  [XmlAttribute]
  public string Color { get; set; } = string.Empty;
  [XmlAttribute]
  public decimal StandardCost { get; set; }
  [XmlAttribute]
  public decimal ListPrice { get; set; }
  [XmlAttribute]
  public string Size { get; set; } = string.Empty;
  [XmlAttribute]
  public DateTime ModifiedDate { get; set; }
  
  #region Static Method to Create a Mock Product
  public static ProductAttributeBased CreateMock()
  {
    // Create an Object
    return new() {
      ProductID = 999,
      Name = "Mock Product",
      ProductNumber = "MOCK-001",
      Color = "White",
      StandardCost = 10,
      ListPrice = 20,
      Size = "Medium",
      ModifiedDate = DateTime.Now
    };
  }
  #endregion

  #region ToString Override 
  public override string ToString()
  {
    return $@"
{Name}  ID: {ProductID}
  Color: {Color ?? "n/a"}  Size: {Size ?? "n/a"}
  Cost: {StandardCost:c}  Price: {ListPrice:c}";
  }
  #endregion
}
