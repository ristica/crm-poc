using Crm.Common.Shared;
using Crm.Common.Utility;
using Crm.Dependencies.Contracts;
using Crm.Models.Base;
using Crm.Models.Contracts.MainDomain;

namespace Crm.Models.MainDomain;

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
        get => _roleNoCommand;
        private set
        {
            if (_roleNoCommand == value) return;
            _roleNoCommand = value;
            OnPropertyChanged();
        }
    }

    public RelayCommand RoleReadCommand
    {
        get => _roleReadCommand;
        private set
        {
            if (_roleReadCommand == value) return;
            _roleReadCommand = value;
            OnPropertyChanged();
        }
    }

    public RelayCommand RoleReadWriteCommand
    {
        get => _roleReadWriteCommand;
        private set
        {
            if (_roleReadWriteCommand == value) return;
            _roleReadWriteCommand = value;
            OnPropertyChanged();
        }
    }

    public RelayCommand RoleReadWriteDeleteCommand
    {
        get => _roleReadWriteDeleteCommand;
        private set
        {
            if (_roleReadWriteDeleteCommand == value) return;
            _roleReadWriteDeleteCommand = value;
            OnPropertyChanged();
        }
    }

    public RelayCommand OpenReadFormCommand
    {
        get => _openReadFormCommand;
        private set
        {
            if (_openReadFormCommand == value) return;
            _openReadFormCommand = value;
            OnPropertyChanged();
        }
    }

    public RelayCommand OpenReadWriteFormCommand
    {
        get => _openReadWriteFormCommand;
        private set
        {
            if (_openReadWriteFormCommand == value) return;
            _openReadWriteFormCommand = value;
            OnPropertyChanged();
        }
    }

    public RelayCommand OpenReadWriteDeleteFormCommand
    {
        get => _openReadWriteDeleteFormCommand;
        private set
        {
            if (_openReadWriteDeleteFormCommand == value) return;
            _openReadWriteDeleteFormCommand = value;
            OnPropertyChanged();
        }
    }

    #endregion

    #region C-TOR

    public MainViewModel(IDependencyContainer dependencyContainer) : base(dependencyContainer)
    {
        InitializeCommands();
    }

    #endregion

    #region METHODS

    protected override void NotifyCommands()
    {
        OpenReadFormCommand.NotifyCanExecuteChanged();
        OpenReadWriteFormCommand.NotifyCanExecuteChanged();
        OpenReadWriteDeleteFormCommand.NotifyCanExecuteChanged();
    }

    #endregion

    #region HELPERS

    private void InitializeCommands()
    {
        RoleNoCommand =
            new RelayCommand(ExecuteRoleNoCommand, CanExecuteRoleNoCommand);
        RoleReadCommand =
            new RelayCommand(ExecuteRoleReadCommand, CanExecuteRoleReadCommand);
        RoleReadWriteCommand =
            new RelayCommand(ExecuteRoleReadWriteCommand, CanExecuteRoleReadWriteCommand);
        RoleReadWriteDeleteCommand =
            new RelayCommand(ExecuteRoleReadWriteDeleteCommand, CanExecuteRoleReadWriteDeleteCommand);
        OpenReadFormCommand =
            new RelayCommand(ExecuteOpenReadFormCommand, CanExecuteOpenReadFormCommand);
        OpenReadWriteFormCommand =
            new RelayCommand(ExecuteOpenReadWriteFormCommand, CanExecuteOpenReadWriteFormCommand);
        OpenReadWriteDeleteFormCommand =
            new RelayCommand(ExecuteOpenReadWriteDeleteFormCommand, CanExecuteOpenReadWriteDeleteFormCommand);
    }

    #endregion

    #region CAN EXECUTE

    private bool CanExecuteRoleNoCommand()
    {
        return true;
    }

    private bool CanExecuteRoleReadCommand()
    {
        return true;
    }

    private bool CanExecuteRoleReadWriteCommand()
    {
        return true;
    }

    private bool CanExecuteRoleReadWriteDeleteCommand()
    {
        return true;
    }

    private bool CanExecuteOpenReadFormCommand()
    {
        return IsRead;
    }

    private bool CanExecuteOpenReadWriteFormCommand()
    {
        return IsReadWrite;
    }

    private bool CanExecuteOpenReadWriteDeleteFormCommand()
    {
        return IsReadWriteDelete;
    }

    #endregion

    #region EXECUTE

    private void ExecuteRoleNoCommand()
    {
        MessageNotificationsHelper.Publish(
            this,
            new MenuRoleEventArgs(MenuRoleConstants.NoRole),
            (int)MessageType.RoleChangedMessage);
    }

    private void ExecuteRoleReadCommand()
    {
        MessageNotificationsHelper.Publish(
            this,
            new MenuRoleEventArgs(MenuRoleConstants.Read),
            (int)MessageType.RoleChangedMessage);
    }

    private void ExecuteRoleReadWriteCommand()
    {
        MessageNotificationsHelper.Publish(
            this,
            new MenuRoleEventArgs(MenuRoleConstants.ReadWrite),
            (int)MessageType.RoleChangedMessage);
    }

    private void ExecuteRoleReadWriteDeleteCommand()
    {
        MessageNotificationsHelper.Publish(
            this,
            new MenuRoleEventArgs(MenuRoleConstants.ReadWriteDelete),
            (int)MessageType.RoleChangedMessage);
    }

    private void ExecuteOpenReadFormCommand()
    {
        MessageNotificationsHelper.Publish(
            this,
            new MenuFormsEventArgs(MenuFormsConstants.Books),
            (int)MessageType.FormChangedMessage);
    }

    private void ExecuteOpenReadWriteFormCommand()
    {
        MessageNotificationsHelper.Publish(
            this,
            new MenuFormsEventArgs(MenuFormsConstants.AddBook),
            (int)MessageType.FormChangedMessage);
    }

    private void ExecuteOpenReadWriteDeleteFormCommand()
    {
        MessageNotificationsHelper.Publish(
            this,
            new MenuFormsEventArgs(MenuFormsConstants.DeleteBook),
            (int)MessageType.FormChangedMessage);
    }

    #endregion
}