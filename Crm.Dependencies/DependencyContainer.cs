using System.Diagnostics;
using Crm.Dependencies.Contracts;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace Crm.Dependencies;

public class DependencyContainer : IDependencyContainer
{
    private IUnityContainer? _container;
    private static readonly Dictionary<Type, List<string>> RegisteredIdentifiers = new();

    public DependencyContainer(IUnityContainer? container = null)
    {
        if (container == null)
        {
            _container = new UnityContainer();
            RegisterType<IDependencyContainer, DependencyContainer>();
        }
        else
        {
            _container = container;
        }
    }

    public TRequested Resolve<TRequested>()
        where TRequested : class
    {
        return _container.Resolve<TRequested>();
    }

    public TRequested Resolve<TRequested>(string identifier)
        where TRequested : class
    {
        return _container.Resolve<TRequested>(identifier);
    }

    public IDependencyContainer RegisterType<TInterface, TImplementation>()
        where TImplementation : class, TInterface
        where TInterface : class
    {
        _container.RegisterType<TInterface, TImplementation>();
        return this;
    }

    public IDependencyContainer RegisterMultipleOfType<TInterface, TImplementation>(string identifier)
        where TImplementation : class, TInterface
        where TInterface : class
    {
        _container.RegisterType<TInterface, TImplementation>(identifier);
        // alle Identifier zu einem Interface werden in einer Liste vermerkt
        lock (RegisteredIdentifiers)
        {
            List<string> identifierList = null;
            if (RegisteredIdentifiers.ContainsKey(typeof(TInterface)))
            {
                identifierList = RegisteredIdentifiers[typeof(TInterface)];
            }
            else
            {
                identifierList = new List<string>();
                RegisteredIdentifiers[typeof(TInterface)] = identifierList;
            }

            if (!identifierList.Contains(identifier)) identifierList.Add(identifier);
        }

        return this;
    }

    public IDependencyContainer RegisterTypeAsSingleton<TInterface, TImplementation>()
        where TImplementation : class, TInterface
        where TInterface : class
    {
        _container.RegisterType<TInterface, TImplementation>(new ContainerControlledLifetimeManager());
        return this;
    }

    public IDependencyContainer RegisterType<TImplementation>()
        where TImplementation : class
    {
        _container.RegisterType<TImplementation>();
        return this;
    }

    public IDependencyContainer RegisterTypeAsSingleton<TImplementation>()
        where TImplementation : class
    {
        _container.RegisterType<TImplementation>(new ContainerControlledLifetimeManager());
        return this;
    }

    public IDependencyContainer RegisterTypeInjectionConstructor<TImplementation>()
        where TImplementation : class
    {
        _container.RegisterType<TImplementation>(new InjectionConstructor());
        return this;
    }

    public IDependencyContainer RegisterType(Type interfaceType, Type implementationType)
    {
        if (interfaceType == null || implementationType == null)
            throw new ArgumentNullException("Neither the interfaceType nor the implementation type can be null!");

        if (!interfaceType.IsGenericType &&
            !implementationType.IsGenericType &&
            !interfaceType.IsAssignableFrom(implementationType))
            throw new ArgumentException("implementationType does not implement interfaceType");

        _container.RegisterType(interfaceType, implementationType);
        return this;
    }

    public IDependencyContainer RegisterTypeAsSingleton(Type interfaceType, Type implementationType)
    {
        if (interfaceType == null || implementationType == null)
            throw new ArgumentNullException("Neither the interfaceType nor the implementation type can be null!");

        if (!interfaceType.IsGenericType &&
            !implementationType.IsGenericType &&
            !interfaceType.IsAssignableFrom(implementationType))
            throw new ArgumentException("implementationType does not implement interfaceType");

        _container.RegisterType(interfaceType, implementationType, new ContainerControlledLifetimeManager());
        return this;
    }

    public IDependencyContainer RegisterType(Type pImplementation)
    {
        if (pImplementation == null) throw new ArgumentNullException(nameof(pImplementation));

        _container.RegisterType(pImplementation);
        return this;
    }

    public IDependencyContainer RegisterTypeAsSingleton(Type pImplementation)
    {
        if (pImplementation == null) throw new ArgumentNullException(nameof(pImplementation));

        _container.RegisterType(pImplementation, new ContainerControlledLifetimeManager(), null);
        return this;
    }

    public object Resolve(Type serviceType)
    {
        return _container.Resolve(serviceType);
    }

    public IDependencyContainer RegisterInstance<TInterface>(TInterface instance)
        where TInterface : class
    {
        _container.RegisterInstance<TInterface>(instance);
        return this;
    }

    public IDependencyContainer RegisterInstance<TInterface>(string identifier, TInterface instance)
        where TInterface : class
    {
        _container.RegisterInstance<TInterface>(identifier, instance);
        return this;
    }

    public IDependencyContainer RegisterInstanceAsSingleton<TInterface>(TInterface instance)
        where TInterface : class
    {
        _container.RegisterInstance<TInterface>(instance, new ContainerControlledLifetimeManager());
        return this;
    }

    public IEnumerable<object> ResolveAll(Type pServiceType)
    {
        return _container.ResolveAll(pServiceType);
    }

    public IDependencyContainer CreateChildContainer()
    {
        return new DependencyContainer(_container.CreateChildContainer());
    }

    public IEnumerable<string> GetRegisteredIdentifiers<TInterface>()
        where TInterface : class
    {
        var identifierList = new List<string>();
        if (RegisteredIdentifiers.ContainsKey(typeof(TInterface)))
            identifierList.AddRange(RegisteredIdentifiers[typeof(TInterface)]);
        return identifierList.AsReadOnly();
    }

    public void Dispose()
    {
        try
        {
            _container?.Dispose();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
        finally
        {
            _container = null;
        }
    }

    public bool IsRegistered<TInterface>()
        where TInterface : class
    {
        return _container.IsRegistered<TInterface>();
    }

    public bool IsRegistered<TInterface>(string nameToCheck)
        where TInterface : class
    {
        return _container.IsRegistered<TInterface>(nameToCheck);
    }

    public bool IsRegistered(Type typeToCheck)
    {
        return _container.IsRegistered(typeToCheck);
    }

    public bool IsRegistered(Type typeToCheck, string nameToCheck)
    {
        return _container.IsRegistered(typeToCheck, nameToCheck);
    }
}