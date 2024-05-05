using System.Xml.Linq;

XElement elem = XElement.Parse(@"
<Products>
  <Product>
    <ProductID>706</ProductID>
    <Name>HL Road Frame</Name>
    <Color>Red</Color>
    <ListPrice>1500.00</ListPrice>
  </Product>
</Products>");

// Create new XElement to add
XElement newElem =
  new("Product",
    new XElement("ProductID", "745"),
      new XElement("Name", "Bike Helmet"),
      new XElement("Color", "White"),
      new XElement("ListPrice", "50.99")
  );

// Add new element to XML Document
elem.Add(newElem);

// Display Document
Console.WriteLine(elem);
