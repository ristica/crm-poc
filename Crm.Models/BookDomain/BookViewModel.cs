using Crm.Dependencies.Contracts;
using Crm.Models.Base;
using Crm.Models.Contracts.BookDomain;
using System.Collections.ObjectModel;

namespace Crm.Models.BookDomain;

public class BookViewModel : BaseRoleViewModel, IBookViewModel
{
    #region FIELDS

    private ObservableCollection<IBook> _books;
    private IBook _currentBook;

    #endregion

    #region PROPERTIES

    public ObservableCollection<IBook> Books
    {
        get => _books;
        set
        {
            if (_books == value) return;
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

    #region C-TOR

    public BookViewModel(IDependencyContainer dependencyContainer) : base(dependencyContainer)
    {
        Books = new ObservableCollection<IBook>();
    }

    #endregion

    #region METHODS

    protected override void NotifyCommands()
    {
    }

    #endregion
}