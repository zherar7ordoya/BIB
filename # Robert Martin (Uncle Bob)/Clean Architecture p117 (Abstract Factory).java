// Interfaz Service
public interface Service {
    // Métodos de Service
}

// Clase ConcreteImpl que implementa Service
public class ConcreteImpl implements Service {
    // Implementación de ConcreteImpl
}

// Interfaz ServiceFactory
public interface ServiceFactory<I> {
    I makeSvc();
}

// Clase ServiceFactoryImpl que implementa ServiceFactory<Service>
public class ServiceFactoryImpl implements ServiceFactory<Service> {
    public Service makeSvc() {
        return new ConcreteImpl();
    }
}

// Clase Application
public class Application {
    private final ServiceFactory<Service> serviceFactory;

    public Application(ServiceFactory<Service> serviceFactory) {
        this.serviceFactory = serviceFactory;
    }

    // Métodos y lógica de Application
}
