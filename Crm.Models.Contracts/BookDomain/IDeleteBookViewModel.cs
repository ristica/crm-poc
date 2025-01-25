using System.Collections.ObjectModel;
using Crm.Common.Utility;
using Crm.Models.Contracts.Base;

namespace Crm.Models.Contracts.BookDomain;

public interface IDeleteBookViewModel : IBaseViewModel
{
    ObservableCollection<IBook> Books { get; set; }
    IBook CurrentBook { get; set; }
    RelayCommand DeleteBookCommand { get; }
}