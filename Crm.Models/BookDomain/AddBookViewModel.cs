using Crm.Dependencies.Contracts;
using Crm.Models.Base;
using Crm.Models.Contracts.BookDomain;

namespace Crm.Models.BookDomain
{
    public class AddBookViewModel : BaseRoleViewModel, IAddBookViewModel
    {
        private IBook _book;

        public IBook CurrentBook
        {
            get => this._book;
            set
            {
                this._book = value;
                OnPropertyChanged();
            }
        }
        public AddBookViewModel(IDependencyContainer dependencyContainer) : base(dependencyContainer)
        {
        }

        protected override void NotifyCommands()
        {
            
        }
    }
}
