// Subsistema complejo
class PayCalculator {
    public void calculatePay() {
        System.out.println("Calculating pay...");
    }
}

class HourReporter {
    public void reportHours() {
        System.out.println("Reporting hours...");
    }
}

class EmployeeSaver {
    public void saveEmployee() {
        System.out.println("Saving employee data...");
    }
}

// Fachada
class EmployeeFacade {
    private PayCalculator payCalculator;
    private HourReporter hourReporter;
    private EmployeeSaver employeeSaver;

    public EmployeeFacade() {
        payCalculator = new PayCalculator();
        hourReporter = new HourReporter();
        employeeSaver = new EmployeeSaver();
    }

    public void calculatePay() {
        payCalculator.calculatePay();
    }

    public void reportHours() {
        hourReporter.reportHours();
    }

    public void save() {
        employeeSaver.saveEmployee();
    }
}

// Cliente
public class Main {
    public static void main(String[] args) {
        EmployeeFacade facade = new EmployeeFacade();
        facade.calculatePay();
        facade.reportHours();
        facade.save();
    }
}
