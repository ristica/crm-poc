using Crm.Models.Contracts.BookDomain;

namespace Crm.Repository.Contracts
{
    public interface IBooksRepository
    {
        IBook Get(string isbn);
        void UpdateOrCreate(IBook model);
        void Delete(string isbn);
        IEnumerable<IBook> GetAll();
    }
}
