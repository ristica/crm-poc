using System.Collections.ObjectModel;
using Crm.Common.Contracts;
using Crm.Common.Shared;
using Crm.Dependencies.Contracts;
using Crm.Models.Contracts.BookDomain;
using Crm.Presenters.Base;
using Crm.Presenters.Contracts;
using Crm.Services.Contracts;
using Crm.Views.Contracts.Base;
using Crm.Views.Contracts.Views;

namespace Crm.Presenters;

// ReSharper disable once ClassNeverInstantiated.Global
public class BooksViewPresenter : Presenter, IBooksViewPresenter, IReceiver<EventArgs>
{
    #region FIELDS

    private readonly IFrmBooks _view;
    private readonly IBooksService<IBook> _service;

    #endregion

    #region PROPERTIES

    public IBaseChildView GetView()
    {
        return _view;
    }

    #endregion

    #region C-TOR

    public BooksViewPresenter(IDependencyContainer dependencyContainer) : base(dependencyContainer)
    {
        _view = dependencyContainer.Resolve<IFrmBooks>();
        _service = dependencyContainer.Resolve<IBooksService<IBook>>();

        SubscribeToUserInterfaceEvents();
        SubscribeToNotifications();
        SetDataContext();
    }

    #endregion

    #region METHODS

    protected sealed override void SubscribeToUserInterfaceEvents()
    {
    }

    public void Receive(object sender, EventArgs args, int messageId)
    {
        switch (messageId)
        {
            case (int)MessageType.RoleChangedMessage:
                if (args is not MenuRoleEventArgs roleEventArgs) return;
                var role = roleEventArgs.NewRole;
                if (string.IsNullOrEmpty(role)) return;
                _view.ViewModel.CurrentRole = role;
                break;
            case (int)MessageType.ReloadBooksMessage:
                ((IBookViewModel)_view.ViewModel).Books = new ObservableCollection<IBook>(_service.GetAll());
                _view.UpdateBindings();
                break;
        }
    }

    public void Dispose()
    {
        MessageNotificationsHelper.Unsubscribe(this, (int)MessageType.RoleChangedMessage);
        MessageNotificationsHelper.Unsubscribe(this, (int)MessageType.ReloadBooksMessage);
    }

    public void ShowView(IBaseView mdiContainerForm)
    {
        _view.LoadChildView();
    }

    public void SetCurrentRole(string role)
    {
        _view.ViewModel.CurrentRole = role;
    }

    #endregion

    #region HELPERS

    private void SetDataContext()
    {
        var vm = DependencyContainer.Resolve<IBookViewModel>();
        vm.Books = new ObservableCollection<IBook>(_service.GetAll().ToList());
        _view.ViewModel = vm;
    }

    private void SubscribeToNotifications()
    {
        MessageNotificationsHelper.Subscribe(this, (int)MessageType.RoleChangedMessage);
        MessageNotificationsHelper.Subscribe(this, (int)MessageType.ReloadBooksMessage);
    }

    #endregion
}