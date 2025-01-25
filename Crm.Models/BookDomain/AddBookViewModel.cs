using Crm.Common.Shared;
using Crm.Common.Utility;
using Crm.Dependencies.Contracts;
using Crm.Models.Base;
using Crm.Models.Contracts.BookDomain;

namespace Crm.Models.BookDomain;

public class AddBookViewModel : BaseRoleViewModel, IAddBookViewModel
{
    #region FIELDS

    private IBook _book;
    private RelayCommand _addNewBookCommand;

    #endregion

    #region PROPERTIES

    public IBook CurrentBook
    {
        get => _book;
        set
        {
            _book = value;
            OnPropertyChanged();
        }
    }

    #endregion

    #region COMMANDS

    public RelayCommand AddNewBookCommand
    {
        get => _addNewBookCommand;
        private set
        {
            if (_addNewBookCommand == value) return;
            _addNewBookCommand = value;
            OnPropertyChanged();
        }
    }

    #endregion

    #region C-TOR

    public AddBookViewModel(IDependencyContainer dependencyContainer) : base(dependencyContainer)
    {
        InitializeCommands();
        CurrentBook = dependencyContainer.Resolve<IBook>();
    }

    #endregion

    #region METHODS

    protected override void NotifyCommands()
    {
        AddNewBookCommand.NotifyCanExecuteChanged();
    }

    #endregion

    #region HELPERS

    private void InitializeCommands()
    {
        AddNewBookCommand = new RelayCommand(ExecuteAddNewBookCommand, CanExecuteAddNewBookCommand);
    }

    #endregion

    #region CAN EXECUTEs

    private bool CanExecuteAddNewBookCommand()
    {
        return IsReadWrite;
    }

    #endregion

    #region EXECUTEs

    private void ExecuteAddNewBookCommand()
    {
        MessageNotificationsHelper.Publish(this, new AddBookEventArgs(CurrentBook), (int)MessageType.AddBookMessage);
    }

    #endregion
}