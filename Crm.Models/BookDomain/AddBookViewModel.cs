using Crm.Common.Shared;
using Crm.Common.Utility;
using Crm.Dependencies.Contracts;
using Crm.Models.Base;
using Crm.Models.Contracts.BookDomain;

namespace Crm.Models.BookDomain
{
    public class AddBookViewModel : BaseRoleViewModel, IAddBookViewModel
    {
        #region FIELDS

        private IBook _book;
        private RelayCommand _addNewBookCommand;

        #endregion

        #region PROPERTIES

        public IBook CurrentBook
        {
            get => this._book;
            set
            {
                this._book = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region COMMANDS

        public RelayCommand AddNewBookCommand
        {
            get => this._addNewBookCommand;
            private set
            {
                if (this._addNewBookCommand == value) return;
                this._addNewBookCommand = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region C-TOR

        public AddBookViewModel(IDependencyContainer dependencyContainer) : base(dependencyContainer)
        {
            this.InitializeCommands();
            this.CurrentBook = dependencyContainer.Resolve<IBook>();
        }

        #endregion

        #region METHODS

        protected override void NotifyCommands()
        {
            this.AddNewBookCommand.NotifyCanExecuteChanged();
        }

        #endregion

        #region HELPERS

        private void InitializeCommands()
        {
            this.AddNewBookCommand = new RelayCommand(ExecuteAddNewBookCommand, CanExecuteAddNewBookCommand);
        }

        #endregion

        #region CAN EXECUTEs

        private bool CanExecuteAddNewBookCommand() => this.IsReadWrite;

        #endregion

        #region EXECUTEs

        private void ExecuteAddNewBookCommand()
        {
            this.MessageNotificationsHelper.Publish(this, new AddBookEventArgs(this.CurrentBook), (int)MessageType.AddBookMessage);
        }

        #endregion
    }
}
