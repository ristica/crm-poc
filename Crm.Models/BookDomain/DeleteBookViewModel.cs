using Crm.Dependencies.Contracts;
using Crm.Models.Base;
using Crm.Models.Contracts.BookDomain;
using System.Collections.ObjectModel;

namespace Crm.Models.BookDomain
{
    public class DeleteBookViewModel : BaseRoleViewModel, IDeleteBookViewModel
    {
        private string _isbn;
        private IEnumerable<IBook> _books;

        public string Isbn
        {
            get => this._isbn;
            set
            {
                this._isbn = value;
                OnPropertyChanged();
            }
        }

        public IEnumerable<IBook> Books
        {
            get => this._books;
            set
            {
                if (Equals(this._books, value)) return;
                this._books = value;
                OnPropertyChanged();
            }
        }

        public DeleteBookViewModel(IDependencyContainer dependencyContainer) : base(dependencyContainer)
        {
            this.Books = new ObservableCollection<IBook>();
        }

        protected override void NotifyCommands()
        {
            
        }
    }
}
