// La interfaz de la fábrica abstracta declara un conjunto de métodos que devuelven
// diferentes productos abstractos. Estos productos se llaman familia y están
// relacionados por un tema o concepto de alto nivel. Los productos de una familia
// suelen ser capaces de colaborar entre sí. Una familia de productos puede tener
// varias variantes, pero los productos de una variante son incompatibles
// con los productos de otra.
interface AbstractFactory {
    AbstractProductA createProductA();
    AbstractProductB createProductB();
}

// Las fábricas concretas producen una familia de productos que pertenecen a una única
// variante. La fábrica garantiza que los productos resultantes sean compatibles.
// Ten en cuenta que las firmas de los métodos de la Fábrica Concreta devuelven un producto
// abstracto, mientras que dentro del método se instancia un producto concreto.
class ConcreteFactory1 implements AbstractFactory {
    
    public AbstractProductA createProductA() {
        return new ConcreteProductA1();
    }

    public AbstractProductB createProductB() {
        return new ConcreteProductB1();
    }
}

// Cada Fábrica Concreta tiene una variante de producto correspondiente.
class ConcreteFactory2 implements AbstractFactory {
    public AbstractProductA createProductA() {
        return new ConcreteProductA2();
    }

    public AbstractProductB createProductB() {
        return new ConcreteProductB2();
    }
}

// Cada producto distinto de una familia de productos debe tener una interfaz base.
// Todas las variantes del producto deben implementar esta interfaz.
interface AbstractProductA {
    String usefulFunctionA();
}

// Los productos concretos son creados por Fábricas Concretas correspondientes.
class ConcreteProductA1 implements AbstractProductA {
    public String usefulFunctionA() {
        return "El resultado del producto A1.";
    }
}

class ConcreteProductA2 implements AbstractProductA {
    public String usefulFunctionA() {
        return "El resultado del producto A2.";
    }
}

// Aquí está la interfaz base de otro producto. Todos los productos pueden
// interactuar entre sí, pero la interacción adecuada es posible solo entre
// productos de la misma variante concreta.
interface AbstractProductB {
    // El Producto B puede hacer su propia tarea...
    String usefulFunctionB();

    // ...pero también puede colaborar con el Producto A.
    //
    // La Fábrica Abstracta se asegura de que todos los productos que crea sean de
    // la misma variante y, por lo tanto, compatibles.
    String anotherUsefulFunctionB(AbstractProductA collaborator);
}

// Los productos concretos son creados por Fábricas Concretas correspondientes.
class ConcreteProductB1 implements AbstractProductB {
    public String usefulFunctionB() {
        return "El resultado del producto B1.";
    }

    // La variante, Producto B1, solo puede funcionar correctamente con la
    // variante, Producto A1. Sin embargo, acepta cualquier instancia de
    // AbstractProductA como argumento.
    public String anotherUsefulFunctionB(AbstractProductA collaborator) {
        String result = collaborator.usefulFunctionA();
        return "El resultado del B1 colaborando con el (" + result + ")";
    }
}

class ConcreteProductB2 implements AbstractProductB {
    public String usefulFunctionB() {
        return "El resultado del producto B2.";
    }

    // La variante, Producto B2, solo puede funcionar correctamente con la
    // variante, Producto A2. Sin embargo, acepta cualquier instancia de
    // AbstractProductA como argumento.
    public String anotherUsefulFunctionB(AbstractProductA collaborator) {
        String result = collaborator.usefulFunctionA();
        return "El resultado del B2 colaborando con el (" + result + ")";
    }
}

// El código del cliente trabaja con fábricas y productos solo a través de tipos abstractos:
// AbstractFactory y AbstractProduct. Esto te permite pasar cualquier subclase de fábrica o
// producto al código del cliente sin romperlo.
class Client {
    public void main() {
        // El código del cliente puede funcionar con cualquier clase de fábrica concreta.
        System.out.println("Cliente: Probando el código del cliente con el primer tipo de fábrica...");
        clientMethod(new ConcreteFactory1());
        System.out.println();

        System.out.println("Cliente: Probando el mismo código de cliente con el segundo tipo de fábrica...");
        clientMethod(new ConcreteFactory2());
    }

    public void clientMethod(AbstractFactory factory) {
        AbstractProductA productA = factory.createProductA();
        AbstractProductB productB = factory.createProductB();

        System.out.println(productB.usefulFunctionB());
        System.out.println(productB.anotherUsefulFunctionB(productA));
    }
}

public class Main {
    public static void main(String[] args) {
        new Client().main();
    }
}
