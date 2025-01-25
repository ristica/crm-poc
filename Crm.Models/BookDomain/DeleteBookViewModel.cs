using Crm.Common.Utility;
using Crm.Dependencies.Contracts;
using Crm.Models.Base;
using Crm.Models.Contracts.BookDomain;
using System.Collections.ObjectModel;
using Crm.Common.Shared;

namespace Crm.Models.BookDomain;

public class DeleteBookViewModel : BaseRoleViewModel, IDeleteBookViewModel
{
    #region FIELDS

    private ObservableCollection<IBook> _books;
    private RelayCommand _deleteBookCommand;
    private IBook _currentBook;

    #endregion

    #region PROPERTIES

    public ObservableCollection<IBook> Books
    {
        get => _books;
        set
        {
            if (Equals(_books, value)) return;
            _books = value;
            OnPropertyChanged();
        }
    }

    public IBook CurrentBook
    {
        get => _currentBook;
        set
        {
            _currentBook = value;
            OnPropertyChanged();
        }
    }

    #endregion

    #region COMMANDS

    public RelayCommand DeleteBookCommand
    {
        get => _deleteBookCommand;
        private set
        {
            if (_deleteBookCommand == value) return;
            _deleteBookCommand = value;
            OnPropertyChanged();
        }
    }

    #endregion

    #region C-TOR

    public DeleteBookViewModel(IDependencyContainer dependencyContainer) : base(dependencyContainer)
    {
        Books = new ObservableCollection<IBook>();
        InitializeCommands();
    }

    #endregion

    #region METHODS

    protected override void NotifyCommands()
    {
        DeleteBookCommand.NotifyCanExecuteChanged();
    }

    #endregion

    #region HELPERS

    private void InitializeCommands()
    {
        DeleteBookCommand = new RelayCommand(ExecuteDeleteBookCommand, CanExecuteDeleteBookCommand);
    }

    #endregion

    #region CAN EXECUTEs

    private bool CanExecuteDeleteBookCommand()
    {
        return IsReadWriteDelete;
    }

    #endregion

    #region EXECUTEs

    private void ExecuteDeleteBookCommand()
    {
        MessageNotificationsHelper.Publish(this, new DeleteBookEventArgs(CurrentBook.Id),
            (int)MessageType.DeleteBookMessage);
    }

    #endregion
}