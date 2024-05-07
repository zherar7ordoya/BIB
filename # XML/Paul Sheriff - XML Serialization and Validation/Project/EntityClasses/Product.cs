namespace XmlSerialization;

public class Product
{
    public int ProductID { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ProductNumber { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public decimal StandardCost { get; set; }
    public decimal ListPrice { get; set; }
    public string Size { get; set; } = string.Empty;
    public DateTime ModifiedDate { get; set; }

    #region Static Method to Create a Mock Product
    public static Product CreateMock()
    {
        // Create an Object
        return new()
        {
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
