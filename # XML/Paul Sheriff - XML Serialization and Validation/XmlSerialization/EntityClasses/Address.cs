namespace XmlSerialization;

//[XmlType(Namespace = $"{Person.BASE_URI}/address")]
//[XmlType(Namespace = "http://www.pdsa.com/address")]
public class Address
{
  public int ID { get; set; }
  public string Street { get; set; } = string.Empty;
  public string City { get; set; } = string.Empty;
  public string State { get; set; } = string.Empty;
  public string PostalCode { get; set; } = string.Empty;
  public string Country { get; set; } = string.Empty;
}
