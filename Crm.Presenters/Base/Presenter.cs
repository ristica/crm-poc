using Crm.Common.Contracts;
using Crm.Dependencies.Contracts;

namespace Crm.Presenters.Base;

public abstract class Presenter
{
    protected readonly IDependencyContainer DependencyContainer;
    protected readonly IMessageNotificationsHelper MessageNotificationsHelper;

    protected Presenter(IDependencyContainer dependencyContainer)
    {
        DependencyContainer = dependencyContainer;
        MessageNotificationsHelper = dependencyContainer.Resolve<IMessageNotificationsHelper>();
    }

    protected abstract void SubscribeToUserInterfaceEvents();
}