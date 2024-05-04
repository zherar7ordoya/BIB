using XmlSerialization;

// Create an Object
Supervisor entity = new()
{
    ID = 42,
    FirstName = "John",
    LastName = "Smith",
    BirthDate =
    Convert.ToDateTime("10/2/1970"),
    HomeAddress = new Address()
    {
        ID = 1,
        Street = "123 Main Street",
        City = "Nashville",
        State = "TN",
        PostalCode = "37011"
    },
    Employees = new List<Employee>() {
    new Employee() {
      ID = 22,
      FirstName = "Sally",
      LastName= "Jones" },
    new Employee() {
      ID = 73,
      FirstName = "Bob",
      LastName= "Cranley" }
  }
};

// Serialize the Object
string xml = entity.Serialize<Supervisor>();

// Display the XML
Console.WriteLine(xml);