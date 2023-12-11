using Crm.Common.Shared;
using Crm.Common.Utility;
using Crm.Dependencies.Contracts;
using Crm.Models.Base;
using Crm.Models.Contracts.MainDomain;

namespace Crm.Models.MainDomain
{
    public class MainViewModel : BaseRoleViewModel, IMainViewModel
    {
        #region FIELDS

        // Menu: ROLES
        private RelayCommand _roleNoCommand;
        private RelayCommand _roleReadCommand;
        private RelayCommand _roleReadWriteCommand;
        private RelayCommand _roleReadWriteDeleteCommand;

        // Menu: Forms
        private RelayCommand _openReadFormCommand;
        private RelayCommand _openReadWriteFormCommand;
        private RelayCommand _openReadWriteDeleteFormCommand;

        #endregion

        #region COMMANDS

        public RelayCommand RoleNoCommand
        {
            get => this._roleNoCommand;
            private set
            {
                if (this._roleNoCommand == value) return;
                this._roleNoCommand = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand RoleReadCommand
        {
            get => this._roleReadCommand;
            private set
            {
                if (this._roleReadCommand == value) return;
                this._roleReadCommand = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand RoleReadWriteCommand
        {
            get => this._roleReadWriteCommand;
            private set
            {
                if (this._roleReadWriteCommand == value) return;
                this._roleReadWriteCommand = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand RoleReadWriteDeleteCommand
        {
            get => this._roleReadWriteDeleteCommand;
            private set
            {
                if (this._roleReadWriteDeleteCommand == value) return;
                this._roleReadWriteDeleteCommand = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand OpenReadFormCommand
        {
            get => this._openReadFormCommand;
            private set
            {
                if (this._openReadFormCommand == value) return;
                this._openReadFormCommand = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand OpenReadWriteFormCommand
        {
            get => this._openReadWriteFormCommand;
            private set
            {
                if (this._openReadWriteFormCommand == value) return;
                this._openReadWriteFormCommand = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand OpenReadWriteDeleteFormCommand
        {
            get => this._openReadWriteDeleteFormCommand;
            private set
            {
                if (this._openReadWriteDeleteFormCommand == value) return;
                this._openReadWriteDeleteFormCommand = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region C-TOR

        public MainViewModel(IDependencyContainer dependencyContainer) : base(dependencyContainer)
        {
            this.InitializeCommands();
        }

        #endregion

        #region METHODS

        protected override void NotifyCommands()
        {
            this.OpenReadFormCommand.NotifyCanExecuteChanged();
            this.OpenReadWriteFormCommand.NotifyCanExecuteChanged();
            this.OpenReadWriteDeleteFormCommand.NotifyCanExecuteChanged();
        }

        #endregion

        #region HELPERS

        private void InitializeCommands()
        {
            this.RoleNoCommand =
                new RelayCommand(ExecuteRoleNoCommand, CanExecuteRoleNoCommand);
            this.RoleReadCommand =
                new RelayCommand(ExecuteRoleReadCommand, CanExecuteRoleReadCommand);
            this.RoleReadWriteCommand =
                new RelayCommand(ExecuteRoleReadWriteCommand, CanExecuteRoleReadWriteCommand);
            this.RoleReadWriteDeleteCommand =
                new RelayCommand(ExecuteRoleReadWriteDeleteCommand, CanExecuteRoleReadWriteDeleteCommand);
            this.OpenReadFormCommand =
                new RelayCommand(ExecuteOpenReadFormCommand, CanExecuteOpenReadFormCommand);
            this.OpenReadWriteFormCommand =
                new RelayCommand(ExecuteOpenReadWriteFormCommand, CanExecuteOpenReadWriteFormCommand);
            this.OpenReadWriteDeleteFormCommand =
                new RelayCommand(ExecuteOpenReadWriteDeleteFormCommand, CanExecuteOpenReadWriteDeleteFormCommand);
        }

        #endregion

        #region CAN EXECUTE

        private bool CanExecuteRoleNoCommand() => true;
        private bool CanExecuteRoleReadCommand() => true;
        private bool CanExecuteRoleReadWriteCommand() => true;
        private bool CanExecuteRoleReadWriteDeleteCommand() => true;
        private bool CanExecuteOpenReadFormCommand() => this.IsRead;
        private bool CanExecuteOpenReadWriteFormCommand() => this.IsReadWrite;
        private bool CanExecuteOpenReadWriteDeleteFormCommand() => this.IsReadWriteDelete;

        #endregion

        #region EXECUTE

        private void ExecuteRoleNoCommand()
        {
            this.MessageNotificationsHelper.Publish(
                this,
                new MenuRoleEventArgs(Common.Shared.MenuRoleConstants.NoRole),
                (int)MessageType.RoleChangedMessage);
        }

        private void ExecuteRoleReadCommand()
        {
            this.MessageNotificationsHelper.Publish(
                this,
                new MenuRoleEventArgs(Common.Shared.MenuRoleConstants.Read),
                (int)MessageType.RoleChangedMessage);
        }

        private void ExecuteRoleReadWriteCommand()
        {
            this.MessageNotificationsHelper.Publish(
                this,
                new MenuRoleEventArgs(Common.Shared.MenuRoleConstants.ReadWrite),
                (int)MessageType.RoleChangedMessage);
        }

        private void ExecuteRoleReadWriteDeleteCommand()
        {
            this.MessageNotificationsHelper.Publish(
                this,
                new MenuRoleEventArgs(Common.Shared.MenuRoleConstants.ReadWriteDelete),
                (int)MessageType.RoleChangedMessage);
        }

        private void ExecuteOpenReadFormCommand()
        {
            this.MessageNotificationsHelper.Publish(
                this,
                new MenuFormsEventArgs(Common.Shared.MenuFormsConstants.Books),
                (int)MessageType.FormChangedMessage);
        }

        private void ExecuteOpenReadWriteFormCommand()
        {
            this.MessageNotificationsHelper.Publish(
                this,
                new MenuFormsEventArgs(Common.Shared.MenuFormsConstants.AddBook),
                (int)MessageType.FormChangedMessage);
        }

        private void ExecuteOpenReadWriteDeleteFormCommand()
        {
            this.MessageNotificationsHelper.Publish(
                this,
                new MenuFormsEventArgs(Common.Shared.MenuFormsConstants.DeleteBook),
                (int)MessageType.FormChangedMessage);
        }

        #endregion
    }
}
