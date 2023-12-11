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

        #endregion

        #region C-TOR

        public MainViewPresenter(IDependencyContainer dependencyContainer) : base(dependencyContainer)
        {
            this._view = dependencyContainer.Resolve<IFrmMain>();

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
            switch (messageId)
            {
                case (int)MessageType.RoleChangedMessage:

                    if(args is not MenuRoleEventArgs menuRoleEventArgs) return;
                    var role = menuRoleEventArgs.NewRole;
                    if (string.IsNullOrEmpty(role)) return;
                    this._view.ViewModel.CurrentRole = role;

                    break;
                case (int)MessageType.FormChangedMessage:

                    if (args is not MenuFormsEventArgs menuFormsEventArgs) return;
                    var form = menuFormsEventArgs.NewForm;
                    if (string.IsNullOrEmpty(form)) return;

                    IBaseChildView view = null;

                    switch (menuFormsEventArgs.NewForm)
                    {
                        case MenuFormsConstants.Books:
                            var presenter = DependencyContainer.Resolve<IBooksViewPresenter>();
                            var newView = presenter.GetView();
                            var exists = this._view.Children.SingleOrDefault(child => child.GetType() == newView.GetType());
                            if (exists == null)
                            {
                                presenter.SetCurrentRole(this._view.ViewModel.CurrentRole);
                                this._view.Children.Add(newView);
                                view = newView;
                            }
                            else
                            {
                                this._view.MaximizeChild(exists);
                            }
                            break;
                        case MenuFormsConstants.AddBook:
                            break;
                        case MenuFormsConstants.DeleteBook:
                            break;
                        default:
                            break;
                    }

                    if (view == null) return;

                    view.MdiContainerForm = this.GetView();
                    view.LoadChildView();

                    break;
            }
        }

        public void Dispose()
        {
            // ReSharper disable once EventUnsubscriptionViaAnonymousDelegate
            this._view.FormLoadEventRaised -= (sender, args) => { };
            // ReSharper disable once EventUnsubscriptionViaAnonymousDelegate
            this._view.FormCloseEventRaised -= (sender, args) => { };

            this.MessageNotificationsHelper.Unsubscribe(this, (int)MessageType.RoleChangedMessage);
            this.MessageNotificationsHelper.Unsubscribe(this, (int)MessageType.FormChangedMessage);

            this.MessageNotificationsHelper.Dispose();
        }

        #endregion

        #region HELPERS

        protected sealed override void SubscribeToUserInterfaceEvents()
        {
            this._view.FormLoadEventRaised += (sender, args) =>
            {
            };

            this._view.FormCloseEventRaised += (sender, args) =>
            {
                this.Dispose();
            };
        }

        private void SubscribeToNotifications()
        {
            this.MessageNotificationsHelper.Subscribe(this, (int)MessageType.RoleChangedMessage);
            this.MessageNotificationsHelper.Subscribe(this, (int)MessageType.FormChangedMessage);
        }

        #endregion
    }
}
