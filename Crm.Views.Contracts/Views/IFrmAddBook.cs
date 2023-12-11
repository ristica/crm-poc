using System.ComponentModel;
using Crm.Models.Contracts.BookDomain;
using Crm.Views.Contracts.Base;

namespace Crm.Views.Contracts.Views
{
    public interface IFrmAddBook : IBaseChildView, INotifyPropertyChanged
    {
        IAddBookViewModel ViewModel { get; set; }
    }
}
