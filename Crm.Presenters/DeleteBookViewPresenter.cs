﻿using Crm.Common.Contracts;
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
    public class DeleteBookViewPresenter : Presenter, IDeleteBookViewPresenter, IReceiver<EventArgs>
    {
        #region FIELDS

        private readonly IFrmDeleteBook _view;
        private readonly IBooksService<IBook> _service;
        private readonly IMessageNotificationsHelper _messageNotificationsHelper;

        #endregion

        #region PROPERTIES

        public IBaseChildView GetView() => this._view;

        #endregion

        #region C-TOR

        public DeleteBookViewPresenter(IDependencyContainer dependencyContainer) : base(dependencyContainer)
        {
            this._view = dependencyContainer.Resolve<IFrmDeleteBook>();
            this._service = dependencyContainer.Resolve<IBooksService<IBook>>();
            this._messageNotificationsHelper = dependencyContainer.Resolve<IMessageNotificationsHelper>();

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
            if (messageId == (int)MessageType.RoleChangedMessage)
            {
                //if (args is not RoleAndFormEventArgs roleEventArgs) return;

                //var role = roleEventArgs.Next;
                //if (string.IsNullOrEmpty(role)) return;

                //this._view.ViewModel.CurrentRole = role;
            }
        }

        public void Dispose()
        {
            this._messageNotificationsHelper.Unsubscribe(this, (int)MessageType.RoleChangedMessage);
        }

        public void ShowView(IBaseView mdiContainerForm) => this._view.LoadChildView();

        #endregion

        #region HELPERS

        private void SetDataContext()
        {
            this._view.ViewModel = this.DependencyContainer.Resolve<IDeleteBookViewModel>();
        }

        private void SubscribeToNotifications()
        {
            this._messageNotificationsHelper.Subscribe(this, (int)MessageType.RoleChangedMessage);
        }

        #endregion
    }
}