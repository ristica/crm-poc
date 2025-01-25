using Crm.Models.Contracts.Base;
using System.Collections.ObjectModel;

namespace Crm.Models.Contracts.BookDomain;

public interface IBookViewModel : IBaseViewModel
{
    ObservableCollection<IBook> Books { get; set; }
    IBook CurrentBook { get; set; }
}