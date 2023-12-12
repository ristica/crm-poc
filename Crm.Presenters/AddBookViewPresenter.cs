using Crm.Common.Contracts;
using Crm.Common.Shared;
using Crm.Dependencies.Contracts;
using Crm.Models.Contracts.BookDomain;
using Crm.Presenters.Base;
using Crm.Presenters.Contracts;
using Crm.Services.Contracts;
using Crm.Views.Contracts.Base;
using Crm.Views.Contracts.Views;

namespace Crm.Presenters
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class AddBookViewPresenter : Presenter, IAddBookViewPresenter, IReceiver<EventArgs>
    {
        #region FIELDS

        private readonly IFrmAddBook _view;
        private readonly IBooksService<IBook> _service;

        #endregion

        #region PROPERTIES

        public IBaseChildView GetView() => this._view;

        #endregion

        #region C-TOR

        public AddBookViewPresenter(IDependencyContainer dependencyContainer) : base(dependencyContainer)
        {
            this._view = dependencyContainer.Resolve<IFrmAddBook>();
            this._service = dependencyContainer.Resolve<IBooksService<IBook>>();

            this.SubscribeToUserInterfaceEvents();
            this.SubscribeToNotifications();
            this.SetDataContext();
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

                    this._view.ViewModel.CurrentRole = role;
                    break;
                case (int)MessageType.AddBookMessage:
                    if (args is not AddBookEventArgs bookEventArgs) return;

                    this._service.UpdateOrCreate(bookEventArgs.NewBook);
                    ((IAddBookViewModel)this._view.ViewModel).CurrentBook = DependencyContainer.Resolve<IBook>();
                    ((IAddBookViewModel)this._view.ViewModel).CurrentBook.PublishYear = DateTime.Today.Year;

                    this.MessageNotificationsHelper.Publish(
                        this, 
                        EventArgs.Empty, 
                        (int)MessageType.ReloadBooksMessage);

                    break;
            }
        }

        public void ShowView(IBaseView mdiContainerForm) => this._view.LoadChildView();

        protected sealed override void SubscribeToUserInterfaceEvents()
        {
        
        }

        public void SetCurrentRole(string role)
        {
            this._view.ViewModel.CurrentRole = role;
        }

        public void Dispose()
        {
            this.MessageNotificationsHelper.Unsubscribe(this, (int)MessageType.RoleChangedMessage);
            this.MessageNotificationsHelper.Unsubscribe(this, (int)MessageType.AddBookMessage);
        }

        #endregion

        #region HELPERS

        private void SetDataContext()
        {
            this._view.ViewModel = this.DependencyContainer.Resolve<IAddBookViewModel>();
        }

        private void SubscribeToNotifications()
        {
            this.MessageNotificationsHelper.Subscribe(this, (int)MessageType.RoleChangedMessage);
            this.MessageNotificationsHelper.Subscribe(this, (int)MessageType.AddBookMessage);
        }

        #endregion
    }
}
