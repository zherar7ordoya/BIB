using System.Xml.Serialization;

namespace XmlSerialization;

//[XmlType(Namespace = "http://www.pdsa.com/person")]
[XmlInclude(typeof(Employee))]
[XmlInclude(typeof(Supervisor))]
//[XmlType(Namespace = $"{BASE_URI}/person")]
public class Person
{
  //public const string BASE_URI = "http://www.pdsa.com";

  public int ID { get; set; }
  public string FirstName { get; set; } = string.Empty;
  public string LastName { get; set; } = string.Empty;
  public DateTime BirthDate { get; set; }

  public Address HomeAddress { get; set; } = new();

  #region ToString Override
  public override string ToString()
  {
    return $@"[Person] Class
  Name: {LastName},{FirstName}
  Person #: {ID}";
  }
  #endregion
}
