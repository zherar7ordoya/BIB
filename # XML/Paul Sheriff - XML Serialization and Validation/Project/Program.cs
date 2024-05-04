using XmlSerialization;

string XmlFileName =
  @$"{Environment.GetFolderPath(
      Environment.SpecialFolder.MyDocuments)}\Products.xml";

List<Product>? list = new();

// Read XML from a file
string xml = File.ReadAllText(XmlFileName);

// Deserialize XML to an object
list = list.Deserialize(xml);

if (list != null)
{
    foreach (Product row in list)
    {
        if (row != null)
        {
            Console.WriteLine(row.ToString());
        }
    }
}
