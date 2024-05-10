namespace XmlProcessing;

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
