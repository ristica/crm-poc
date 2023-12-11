using Crm.Models.Contracts.Base;

namespace Crm.Models.Contracts.BookDomain
{
    public interface IDeleteBookViewModel : IBaseViewModel
    {
        string Isbn { get; set; }
        IEnumerable<IBook> Books { get; set; }
    }
}
