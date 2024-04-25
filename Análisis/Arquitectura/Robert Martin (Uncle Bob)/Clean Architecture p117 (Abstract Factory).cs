// Interfaz Service
public interface IService
{
    // Métodos de Service
}

// Clase ConcreteImpl que implementa IService
public class ConcreteImpl : IService
{
    // Implementación de ConcreteImpl
}

// Interfaz ServiceFactory
public interface IServiceFactory<I>
{
    I MakeSvc();
}

// Clase ServiceFactoryImpl que implementa IServiceFactory<IService>
public class ServiceFactoryImpl : IServiceFactory<IService>
{
    public IService MakeSvc()
    {
        return new ConcreteImpl();
    }
}

// Clase Application
public class Application
{
    private readonly IServiceFactory<IService> serviceFactory;

    public Application(IServiceFactory<IService> serviceFactory)
    {
        this.serviceFactory = serviceFactory;
    }

    // Métodos y lógica de Application
}
