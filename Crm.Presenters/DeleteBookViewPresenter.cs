using Crm.Common.Contracts;
using Crm.Common.Shared;
using Crm.Dependencies.Contracts;
using Crm.Models.Contracts.BookDomain;
using Crm.Presenters.Base;
using Crm.Presenters.Contracts;
using Crm.Services.Contracts;
using Crm.Views.Contracts.Base;
using Crm.Views.Contracts.Views;
using System.Collections.ObjectModel;

namespace Crm.Presenters
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class DeleteBookViewPresenter : Presenter, IDeleteBookViewPresenter, IReceiver<EventArgs>
    {
        #region FIELDS

        private readonly IFrmDeleteBook _view;
        private readonly IBooksService<IBook> _service;

        #endregion

        #region PROPERTIES

        public IBaseChildView GetView() => this._view;

        #endregion

        #region C-TOR

        public DeleteBookViewPresenter(IDependencyContainer dependencyContainer) : base(dependencyContainer)
        {
            this._view = dependencyContainer.Resolve<IFrmDeleteBook>();
            this._service = dependencyContainer.Resolve<IBooksService<IBook>>();

            this.SubscribeToUserInterfaceEvents();
            this.SubscribeToNotifications();
            this.SetDataContext();
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
                    this._view.ViewModel.CurrentRole = role;
                    break;
                case (int)MessageType.DeleteBookMessage:
                    if (args is not DeleteBookEventArgs deleteEventArgs) return;
                    this._service.Delete(deleteEventArgs.Id);
                    this.MessageNotificationsHelper.Publish(
                        this,
                        EventArgs.Empty,
                        (int)MessageType.ReloadBooksMessage);
                    break;
                case (int)MessageType.ReloadBooksMessage:
                    ((IDeleteBookViewModel)this._view.ViewModel).Books = new ObservableCollection<IBook>(this._service.GetAll());
                    this._view.UpdateBindings();
                    break;
            }
        }

        public void SetCurrentRole(string role)
        {
            this._view.ViewModel.CurrentRole = role;
        }

        public void Dispose()
        {
            this.MessageNotificationsHelper.Unsubscribe(this, (int)MessageType.RoleChangedMessage);
            this.MessageNotificationsHelper.Unsubscribe(this, (int)MessageType.DeleteBookMessage);
            this.MessageNotificationsHelper.Unsubscribe(this, (int)MessageType.ReloadBooksMessage);
        }

        public void ShowView(IBaseView mdiContainerForm) => this._view.LoadChildView();

        #endregion

        #region HELPERS

        private void SetDataContext()
        {
            this._view.ViewModel = this.DependencyContainer.Resolve<IDeleteBookViewModel>();
            ((IDeleteBookViewModel)this._view.ViewModel).Books = new ObservableCollection<IBook>(this._service.GetAll().ToList());
        }

        private void SubscribeToNotifications()
        {
            this.MessageNotificationsHelper.Subscribe(this, (int)MessageType.RoleChangedMessage);
            this.MessageNotificationsHelper.Subscribe(this, (int)MessageType.DeleteBookMessage);
            this.MessageNotificationsHelper.Subscribe(this, (int)MessageType.ReloadBooksMessage);
        }

        #endregion
    }
}
