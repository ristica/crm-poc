using Crm.Common.Contracts;
using Crm.Common.Shared;
using Crm.Dependencies.Contracts;
using Crm.Models.Contracts.BookDomain;
using Crm.Presenters.Base;
using Crm.Presenters.Contracts;
using Crm.Presenters.Contracts.Base;
using Crm.Views.Contracts.Base;
using Crm.Views.Contracts.Views;

namespace Crm.Presenters;

public class MainViewPresenter : Presenter, IMainViewPresenter, IReceiver<EventArgs>
{
    #region FIELDS

    private readonly IFrmMain _view;

    #endregion

    #region C-TOR

    public MainViewPresenter(IDependencyContainer dependencyContainer) : base(dependencyContainer)
    {
        _view = dependencyContainer.Resolve<IFrmMain>();

        SubscribeToUserInterfaceEvents();
        SubscribeToNotifications();
    }

    #endregion

    #region METHODS

    public IBaseView GetView()
    {
        return _view;
    }

    public void ShowView()
    {
        // intentionally left blank ...
    }

    public void Receive(object sender, EventArgs args, int messageId)
    {
        switch (messageId)
        {
            case (int)MessageType.RoleChangedMessage:

                if (args is not MenuRoleEventArgs menuRoleEventArgs) return;
                var role = menuRoleEventArgs.NewRole;
                if (string.IsNullOrEmpty(role)) return;
                _view.ViewModel.CurrentRole = role;

                break;
            case (int)MessageType.FormChangedMessage:

                if (args is not MenuFormsEventArgs menuFormsEventArgs) return;
                var form = menuFormsEventArgs.NewForm;
                if (string.IsNullOrEmpty(form)) return;

                var view = menuFormsEventArgs.NewForm switch
                {
                    MenuFormsConstants.Books => CreateOrLoadView(typeof(IBooksViewPresenter), typeof(IBookViewModel)),
                    MenuFormsConstants.AddBook => CreateOrLoadView(typeof(IAddBookViewPresenter),
                        typeof(IAddBookViewModel)),
                    MenuFormsConstants.DeleteBook => CreateOrLoadView(typeof(IDeleteBookViewPresenter),
                        typeof(IDeleteBookViewModel)),
                    _ => null
                };

                if (view == null) return;

                view.MdiContainerForm = GetView();
                view.LoadChildView();

                break;
        }
    }

    public void Dispose()
    {
        // ReSharper disable once EventUnsubscriptionViaAnonymousDelegate
        _view.FormLoadEventRaised -= (sender, args) => { };
        // ReSharper disable once EventUnsubscriptionViaAnonymousDelegate
        _view.FormCloseEventRaised -= (sender, args) => { };

        MessageNotificationsHelper.Unsubscribe(this, (int)MessageType.RoleChangedMessage);
        MessageNotificationsHelper.Unsubscribe(this, (int)MessageType.FormChangedMessage);

        MessageNotificationsHelper.Dispose();
    }

    #endregion

    #region HELPERS

    private IBaseChildView? CreateOrLoadView(Type presenter, Type viewModel)
    {
        var exists =
            _view.Children.SingleOrDefault(child => child.ViewModel.GetType().GetInterface(viewModel.Name) != null);
        if (exists == null)
        {
            _view.MinimizeChildren();

            var p = DependencyContainer.Resolve(presenter) as IBaseChildViewPresenter;
            p.SetCurrentRole(_view.ViewModel.CurrentRole);
            _view.Children.Add(p.GetView());
            return p.GetView();
        }

        _view.MaximizeChild(exists);
        return null;
    }

    protected sealed override void SubscribeToUserInterfaceEvents()
    {
        _view.FormLoadEventRaised += (sender, args) => { };

        _view.FormCloseEventRaised += (sender, args) => { Dispose(); };
    }

    private void SubscribeToNotifications()
    {
        MessageNotificationsHelper.Subscribe(this, (int)MessageType.RoleChangedMessage);
        MessageNotificationsHelper.Subscribe(this, (int)MessageType.FormChangedMessage);
    }

    #endregion
}