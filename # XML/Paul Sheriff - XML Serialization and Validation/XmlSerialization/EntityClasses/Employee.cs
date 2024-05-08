namespace XmlSerialization;

//[XmlType(Namespace = $"{BASE_URI}/employee")]
public class Employee : Person
{
  public decimal Salary { get; set; }

  #region ToString Override
  public override string ToString()
  {
        return $@"[Employee] Class
            Name: {FirstName} {LastName}
            Employee #: {ID}";
  }
  #endregion
}
