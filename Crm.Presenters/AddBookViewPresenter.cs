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
public class AddBookViewPresenter : Presenter, IAddBookViewPresenter, IReceiver<EventArgs>
{
    #region FIELDS

    private readonly IFrmAddBook _view;
    private readonly IBooksService<IBook> _service;

    #endregion

    #region PROPERTIES

    public IBaseChildView GetView()
    {
        return _view;
    }

    #endregion

    #region C-TOR

    public AddBookViewPresenter(IDependencyContainer dependencyContainer) : base(dependencyContainer)
    {
        _view = dependencyContainer.Resolve<IFrmAddBook>();
        _service = dependencyContainer.Resolve<IBooksService<IBook>>();

        SubscribeToUserInterfaceEvents();
        SubscribeToNotifications();
        SetDataContext();
    }

    #endregion

    #region METHODS

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
            case (int)MessageType.AddBookMessage:
                if (args is not AddBookEventArgs bookEventArgs) return;

                _service.UpdateOrCreate(bookEventArgs.NewBook);
                ((IAddBookViewModel)_view.ViewModel).CurrentBook = DependencyContainer.Resolve<IBook>();
                ((IAddBookViewModel)_view.ViewModel).CurrentBook.PublishYear = DateTime.Today.Year;

                MessageNotificationsHelper.Publish(
                    this,
                    EventArgs.Empty,
                    (int)MessageType.ReloadBooksMessage);

                break;
        }
    }

    public void ShowView(IBaseView mdiContainerForm)
    {
        _view.LoadChildView();
    }

    protected sealed override void SubscribeToUserInterfaceEvents()
    {
    }

    public void SetCurrentRole(string role)
    {
        _view.ViewModel.CurrentRole = role;
    }

    public void Dispose()
    {
        MessageNotificationsHelper.Unsubscribe(this, (int)MessageType.RoleChangedMessage);
        MessageNotificationsHelper.Unsubscribe(this, (int)MessageType.AddBookMessage);
    }

    #endregion

    #region HELPERS

    private void SetDataContext()
    {
        _view.ViewModel = DependencyContainer.Resolve<IAddBookViewModel>();
    }

    private void SubscribeToNotifications()
    {
        MessageNotificationsHelper.Subscribe(this, (int)MessageType.RoleChangedMessage);
        MessageNotificationsHelper.Subscribe(this, (int)MessageType.AddBookMessage);
    }

    #endregion
}