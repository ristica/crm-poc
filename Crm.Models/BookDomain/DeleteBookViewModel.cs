using Crm.Common.Utility;
using Crm.Dependencies.Contracts;
using Crm.Models.Base;
using Crm.Models.Contracts.BookDomain;
using System.Collections.ObjectModel;
using Crm.Common.Shared;

namespace Crm.Models.BookDomain
{
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
            get => this._books;
            set
            {
                if (Equals(this._books, value)) return;
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

        #region COMMANDS

        public RelayCommand DeleteBookCommand
        {
            get => this._deleteBookCommand;
            private set
            {
                if (this._deleteBookCommand == value) return;
                this._deleteBookCommand = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region C-TOR

        public DeleteBookViewModel(IDependencyContainer dependencyContainer) : base(dependencyContainer)
        {
            this.Books = new ObservableCollection<IBook>();
            this.InitializeCommands();
        }

        #endregion

        #region METHODS

        protected override void NotifyCommands()
        {
            this.DeleteBookCommand.NotifyCanExecuteChanged();
        }

        #endregion

        #region HELPERS

        private void InitializeCommands()
        {
            this.DeleteBookCommand = new RelayCommand(ExecuteDeleteBookCommand, CanExecuteDeleteBookCommand);
        }

        #endregion

        #region CAN EXECUTEs

        private bool CanExecuteDeleteBookCommand() => this.IsReadWriteDelete;

        #endregion

        #region EXECUTEs

        private void ExecuteDeleteBookCommand()
        {
            this.MessageNotificationsHelper.Publish(this, new DeleteBookEventArgs(this.CurrentBook.Id), (int)MessageType.DeleteBookMessage);
        }

        #endregion
    }
}
