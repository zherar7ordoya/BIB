using XmlSerialization;

string XmlFileName =
  @$"{Environment.GetFolderPath(
      Environment.SpecialFolder.MyDocuments)}\ProductWithAttributes.xml";

// Create an Object
ProductWithAttributes entity =
  ProductWithAttributes.CreateMock();
entity.ProductDescription = "A description";
entity.Color = null;
entity.Size = null;

// Serialize the Object
string xml =
  entity.Serialize<ProductWithAttributes>();

// Write XML to File
File.WriteAllText(XmlFileName, xml,
  System.Text.Encoding.Unicode);

// Display the XML
Console.WriteLine(xml);
Console.WriteLine(
  $"View the XML in '{XmlFileName}'");
