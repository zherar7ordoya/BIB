using System;

// Subsistema complejo
public class PayCalculator
{
    public void CalculatePay()
    {
        Console.WriteLine("Calculating pay...");
    }
}

public class HourReporter
{
    public void ReportHours()
    {
        Console.WriteLine("Reporting hours...");
    }
}

public class EmployeeSaver
{
    public void SaveEmployee()
    {
        Console.WriteLine("Saving employee data...");
    }
}

// Fachada
public class EmployeeFacade
{
    private PayCalculator payCalculator;
    private HourReporter hourReporter;
    private EmployeeSaver employeeSaver;

    public EmployeeFacade()
    {
        payCalculator = new PayCalculator();
        hourReporter = new HourReporter();
        employeeSaver = new EmployeeSaver();
    }

    public void CalculatePay()
    {
        payCalculator.CalculatePay();
    }

    public void ReportHours()
    {
        hourReporter.ReportHours();
    }

    public void Save()
    {
        employeeSaver.SaveEmployee();
    }
}

// Cliente
class Program
{
    static void Main(string[] args)
    {
        EmployeeFacade facade = new EmployeeFacade();
        facade.CalculatePay();
        facade.ReportHours();
        facade.Save();
    }
}
