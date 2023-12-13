using Crm.Common.Contracts;
using Crm.Common.NotificationBase;
using System.Drawing;
using Crm.Dependencies.Contracts;

namespace Crm.Models.Base
{
    public abstract class BaseRoleViewModel : CommonBase
    {
        #region FIELDS

        protected readonly IDependencyContainer DependencyContainer;
        protected readonly IMessageNotificationsHelper MessageNotificationsHelper;

        private string _currentRole = string.Empty;
        private bool _isRead;
        private bool _isReadWrite;
        private bool _isReadWriteDelete;
        private Color _currentRoleTextColor;

        protected abstract void NotifyCommands();

        #endregion

        #region PROPERTIES

        public string CurrentRole
        {
            get => this._currentRole;
            set
            {
                if (string.IsNullOrEmpty(value) || this._currentRole.Equals(value)) return;
                this._currentRole = value;
                OnPropertyChanged();
                this.Update();
                this.NotifyCommands();
            }
        }

        public bool IsRead
        {
            get => this._isRead;
            private set
            {
                this._isRead = value;
                OnPropertyChanged();
            }
        }

        public bool IsReadWrite
        {
            get => this._isReadWrite;
            private set
            {
                this._isReadWrite = value;
                OnPropertyChanged();
            }
        }

        public bool IsReadWriteDelete
        {
            get => this._isReadWriteDelete;
            private set
            {
                this._isReadWriteDelete = value;
                OnPropertyChanged();
            }
        }

        public Color CurrentRoleTextColor
        {
            get => this._currentRoleTextColor;
            private set
            {
                this._currentRoleTextColor = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region C-TOR

        protected BaseRoleViewModel(IDependencyContainer dependencyContainer)
        {
            this.DependencyContainer = dependencyContainer;
            this.MessageNotificationsHelper = dependencyContainer.Resolve<IMessageNotificationsHelper>();
        }

        #endregion

        #region HELPERS

        private void Update()
        {
            switch (this.CurrentRole)
            {
                case Common.Shared.MenuRoleConstants.Read:
                    this.IsRead = true;
                    this.IsReadWrite = false;
                    this.IsReadWriteDelete = false;
                    this.CurrentRoleTextColor = Color.Blue;
                    break;
                case Common.Shared.MenuRoleConstants.ReadWrite:
                    this.IsRead = true;
                    this.IsReadWrite = true;
                    this.IsReadWriteDelete = false;
                    this.CurrentRoleTextColor = Color.Green;
                    break;
                case Common.Shared.MenuRoleConstants.ReadWriteDelete:
                    this.IsRead = true;
                    this.IsReadWrite = true;
                    this.IsReadWriteDelete = true;
                    this.CurrentRoleTextColor = Color.Red;
                    break;
                default:
                    this.IsRead = false;
                    this.IsReadWrite = false;
                    this.IsReadWriteDelete = false;
                    this.CurrentRoleTextColor = Color.Black;
                    break;
            }
        }

        #endregion
    }
}
