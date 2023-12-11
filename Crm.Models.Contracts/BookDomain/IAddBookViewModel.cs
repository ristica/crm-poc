using Crm.Models.Contracts.Base;

namespace Crm.Models.Contracts.BookDomain
{
    public interface IAddBookViewModel : IBaseViewModel
    {
        IBook CurrentBook { get; set; }
    }
}
