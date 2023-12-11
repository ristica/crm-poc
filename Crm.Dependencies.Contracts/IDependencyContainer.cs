namespace Crm.Dependencies.Contracts
{
    public interface IDependencyContainer : IDisposable
    {
        TRequested Resolve<TRequested>()
            where TRequested : class;

        TRequested Resolve<TRequested>(string identifier)
            where TRequested : class;

        IDependencyContainer RegisterType<TInterface, TImplementation>()
            where TImplementation : class, TInterface
            where TInterface : class;

        IDependencyContainer RegisterMultipleOfType<TInterface, TImplementation>(string identifier)
            where TImplementation : class, TInterface
            where TInterface : class;

        IDependencyContainer RegisterTypeAsSingleton<TInterface, TImplementation>()
            where TImplementation : class, TInterface
            where TInterface : class;

        IDependencyContainer RegisterType<TImplementation>()
            where TImplementation : class;

        IDependencyContainer RegisterTypeAsSingleton<TImplementation>()
            where TImplementation : class;

        IDependencyContainer RegisterTypeInjectionConstructor<TImplementation>()
            where TImplementation : class;

        object Resolve(Type serviceType);

        IEnumerable<object> ResolveAll(Type pServiceType);

        IDependencyContainer CreateChildContainer();

        IDependencyContainer RegisterInstance<TInterface>(TInterface instance)
            where TInterface : class;

        IDependencyContainer RegisterInstance<TInterface>(string identifier, TInterface instance)
            where TInterface : class;

        IDependencyContainer RegisterInstanceAsSingleton<TInterface>(TInterface instance)
            where TInterface : class;

        IDependencyContainer RegisterType(Type pInterface, Type pImplementation);

        IDependencyContainer RegisterTypeAsSingleton(Type interfaceType, Type implementationType);

        IDependencyContainer RegisterType(Type pImplementation);

        IDependencyContainer RegisterTypeAsSingleton(Type pImplementation);

        IEnumerable<string> GetRegisteredIdentifiers<TInterface>()
            where TInterface : class;

        bool IsRegistered<TInterface>()
            where TInterface : class;

        bool IsRegistered<TInterface>(string nameToCheck)
            where TInterface : class;

        bool IsRegistered(Type typeToCheck);

        bool IsRegistered(Type typeToCheck, string nameToCheck);
    }
}
