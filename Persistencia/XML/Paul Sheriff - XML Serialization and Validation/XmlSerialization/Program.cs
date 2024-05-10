using XmlSerialization;

string XmlFileName =
  @$"{Environment.GetFolderPath(
      Environment.SpecialFolder.MyDocuments)}\ProductList.xml";

ProductCollection productos = new()
{
    Products = new()
{
  new Product {
    ProductID = 680,
    Name = @"HL Road Frame - Black, 58",
    ProductNumber = @"FR-R92B-58",
    Color = @"Black",
    StandardCost = 1059.3100m,
    ListPrice = 1431.5000m,
    Size = @"58",
    ModifiedDate =
      Convert.ToDateTime("3/11/2008")
  },
  new Product {
    ProductID = 706,
    Name = @"HL Road Frame - Red, 58",
    ProductNumber = @"FR-R92R-58",
    Color = @"Red",
    StandardCost = 1059.3100m,
    ListPrice = 1431.5000m,
    Size = @"58",
    ModifiedDate =
      Convert.ToDateTime("3/11/2008")
  }
}
};

// Serialize the Object
string xml = productos.MapearHaciaXml<ProductCollection>();

// Write XML to File
File.WriteAllText(XmlFileName, xml,
  System.Text.Encoding.Unicode);

// Display the XML
Console.WriteLine(xml);
Console.WriteLine(
  $"View the XML in '{XmlFileName}'");