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

namespace Crm.Presenters
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class BooksViewPresenter : Presenter, IBooksViewPresenter, IReceiver<EventArgs>
    {
        #region FIELDS
        
        private readonly IFrmBooks _view;
        private readonly IBooksService<IBook> _service;

        #endregion

        #region PROPERTIES

        public IBaseChildView GetView() => this._view;

        #endregion

        #region C-TOR

        public BooksViewPresenter(IDependencyContainer dependencyContainer) : base(dependencyContainer)
        {
            this._view = dependencyContainer.Resolve<IFrmBooks>();
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
                case (int)MessageType.ReloadBooksMessage:
                    ((IBookViewModel)this._view.ViewModel).Books = new ObservableCollection<IBook>(this._service.GetAll());
                    this._view.UpdateBindings();
                    break;
            }
        }

        public void Dispose()
        {
            this.MessageNotificationsHelper.Unsubscribe(this, (int)MessageType.RoleChangedMessage);
            this.MessageNotificationsHelper.Unsubscribe(this, (int)MessageType.ReloadBooksMessage);
        }

        public void ShowView(IBaseView mdiContainerForm) => this._view.LoadChildView();

        public void SetCurrentRole(string role)
        {
            this._view.ViewModel.CurrentRole = role;
        }

        #endregion

        #region HELPERS

        private void SetDataContext()
        {
            var vm = DependencyContainer.Resolve<IBookViewModel>();
            vm.Books = new ObservableCollection<IBook>(this._service.GetAll().ToList());
            this._view.ViewModel = vm;
        }

        private void SubscribeToNotifications()
        {
            this.MessageNotificationsHelper.Subscribe(this, (int)MessageType.RoleChangedMessage);
            this.MessageNotificationsHelper.Subscribe(this, (int)MessageType.ReloadBooksMessage);
        }

        #endregion
    }
}
