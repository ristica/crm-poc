using Crm.Dependencies.Contracts;
using Crm.Models.Base;
using Crm.Models.Contracts.BookDomain;
using System.Collections.ObjectModel;

namespace Crm.Models.BookDomain
{
    public class BookViewModel : BaseRoleViewModel, IBookViewModel
    {
        #region FIELDS

        private ObservableCollection<IBook> _books;
        private IBook _currentBook;

        #endregion

        #region PROPERTIES

        public ObservableCollection<IBook> Books
        {
            get => this._books;
            set
            {
                if (this._books == value) return;
                this._books = value;
                OnPropertyChanged();
            }
        }

        public IBook CurrentBook
        {
            get => this._currentBook;
            set
            {
                this._currentBook = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region C-TOR

        public BookViewModel(IDependencyContainer dependencyContainer) : base(dependencyContainer)
        {
            this.Books = new ObservableCollection<IBook>();
        }

        #endregion

        #region METHODS

        protected override void NotifyCommands()
        {
            
        }

        #endregion
    }
}
