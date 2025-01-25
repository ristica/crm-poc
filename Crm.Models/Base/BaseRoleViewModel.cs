using Crm.Common.Contracts;
using Crm.Common.NotificationBase;
using System.Drawing;
using Crm.Dependencies.Contracts;

namespace Crm.Models.Base;

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
        get => _currentRole;
        set
        {
            if (string.IsNullOrEmpty(value) || _currentRole.Equals(value)) return;
            _currentRole = value;
            OnPropertyChanged();
            Update();
            NotifyCommands();
        }
    }

    public bool IsRead
    {
        get => _isRead;
        private set
        {
            _isRead = value;
            OnPropertyChanged();
        }
    }

    public bool IsReadWrite
    {
        get => _isReadWrite;
        private set
        {
            _isReadWrite = value;
            OnPropertyChanged();
        }
    }

    public bool IsReadWriteDelete
    {
        get => _isReadWriteDelete;
        private set
        {
            _isReadWriteDelete = value;
            OnPropertyChanged();
        }
    }

    public Color CurrentRoleTextColor
    {
        get => _currentRoleTextColor;
        private set
        {
            _currentRoleTextColor = value;
            OnPropertyChanged();
        }
    }

    #endregion

    #region C-TOR

    protected BaseRoleViewModel(IDependencyContainer dependencyContainer)
    {
        DependencyContainer = dependencyContainer;
        MessageNotificationsHelper = dependencyContainer.Resolve<IMessageNotificationsHelper>();
    }

    #endregion

    #region HELPERS

    private void Update()
    {
        switch (CurrentRole)
        {
            case Common.Shared.MenuRoleConstants.Read:
                IsRead = true;
                IsReadWrite = false;
                IsReadWriteDelete = false;
                CurrentRoleTextColor = Color.Blue;
                break;
            case Common.Shared.MenuRoleConstants.ReadWrite:
                IsRead = true;
                IsReadWrite = true;
                IsReadWriteDelete = false;
                CurrentRoleTextColor = Color.Green;
                break;
            case Common.Shared.MenuRoleConstants.ReadWriteDelete:
                IsRead = true;
                IsReadWrite = true;
                IsReadWriteDelete = true;
                CurrentRoleTextColor = Color.Red;
                break;
            default:
                IsRead = false;
                IsReadWrite = false;
                IsReadWriteDelete = false;
                CurrentRoleTextColor = Color.Black;
                break;
        }
    }

    #endregion
}