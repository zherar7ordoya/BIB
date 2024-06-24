namespace XmlSerialization;

//[XmlType(Namespace = $"{BASE_URI}/supervisor")]
public class Supervisor : Employee
{
  //[XmlArray("DirectReports")]
  //[XmlArrayItem("DirectReport")]
  public List<Employee> Employees { get; set; } = new();

  #region ToString Override
  public override string ToString()
  {
    return $@"[Supervisor] Class
Name: {FirstName} {LastName}
Direct Reports = {Employees.Count}";
  }
  #endregion
}
