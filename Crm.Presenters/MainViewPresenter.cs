using Crm.Common.Contracts;
using Crm.Common.Shared;
using Crm.Dependencies.Contracts;
using Crm.Presenters.Base;
using Crm.Presenters.Contracts;
using Crm.Views.Contracts.Base;
using Crm.Views.Contracts.Views;

namespace Crm.Presenters
{
    public class MainViewPresenter : Presenter, IMainViewPresenter, IReceiver<EventArgs>
    {
        #region FIELDS

        private readonly IFrmMain _view;
        private readonly IMessageNotificationsHelper _messageNotificationsHelper;

        #endregion

        #region C-TOR

        public MainViewPresenter(IDependencyContainer dependencyContainer) : base(dependencyContainer)
        {
            this._view = dependencyContainer.Resolve<IFrmMain>();
            this._messageNotificationsHelper = dependencyContainer.Resolve<IMessageNotificationsHelper>();

            this.SubscribeToUserInterfaceEvents();
            this.SubscribeToNotifications();
        }

        #endregion

        #region METHODS

        public IBaseView GetView() => this._view;

        public void ShowView()
        {
           // intentionally left blank ...
        }

        public void Receive(object sender, EventArgs args, int messageId)
        {
            if (messageId == (int)MessageType.RoleChangedMessage)
            {
                if (args is not MenuRoleEventArgs roleEventArgs) return;

                var role = roleEventArgs.NewRole;
                if (string.IsNullOrEmpty(role)) return;

                this._view.ViewModel.CurrentRole = role;
            }
        }

        public void Dispose()
        {
            // ReSharper disable once EventUnsubscriptionViaAnonymousDelegate
            this._view.FormLoadEventRaised -= (sender, args) => { };
            // ReSharper disable once EventUnsubscriptionViaAnonymousDelegate
            this._view.FormCloseEventRaised -= (sender, args) => { };
            // ReSharper disable once EventUnsubscriptionViaAnonymousDelegate
            this._view.FormChildChangedEvent -= (sender, args) => { };

            this._messageNotificationsHelper.Unsubscribe(this, (int)MessageType.RoleChangedMessage);
            this._messageNotificationsHelper.Dispose();
        }

        #endregion

        #region HELPERS

        protected sealed override void SubscribeToUserInterfaceEvents()
        {
            this._view.FormLoadEventRaised += (sender, args) =>
            {
            };

            this._view.FormChildChangedEvent += (sender, args) =>
            {
                //if (args is not RoleAndFormEventArgs eventArgs) return;

                //IBaseChildView view = null;

                //switch (eventArgs.Next)
                //{
                //    case MenuRoleConstants.Read:
                //        var newView = DependencyContainer.Resolve<IBooksViewPresenter>().GetView();
                //        var exists = this._view.Children.SingleOrDefault(child => child.GetType() == newView.GetType());
                //        if (exists == null)
                //        {
                //            this._view.Children.Add(newView);
                //            view = newView;
                //        }
                //        else this._view.MaximizeChild(exists);
                //        break;
                //    case MenuRoleConstants.ReadWrite:
                //        break;
                //    case MenuRoleConstants.ReadWriteDelete:
                //        break;
                //    default:
                //        break;
                //}

                //if (view == null) return;

                //view.MdiContainerForm = this.GetView();
                //view.LoadChildView();
            };

            this._view.FormCloseEventRaised += (sender, args) =>
            {
                this.Dispose();
            };
        }

        private void SubscribeToNotifications()
        {
            this._messageNotificationsHelper.Subscribe(this, (int)MessageType.RoleChangedMessage);
        }

        #endregion
    }
}
