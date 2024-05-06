using System.Xml.Linq;

XDocument doc =
  new(
    new XDeclaration("1.0", "utf-8", "yes"),
    new XComment("Product Information"),
    new XElement("Products",
      new XElement("Product",
        new XAttribute("ProductID", "1"),
        new XElement("Name", "Bicycle Helmet"),
        new XElement("ProductNumber", "HELM-01"),
        new XElement("Color", "White"),
        new XElement("StandardCost", "24.49"),
        new XElement("ListPrice", "89.99"),
        new XElement("Size", "Medium"))
        )
      );

doc.Save(fileName: "Products.xml");

// Display the Document
Console.WriteLine(doc);
