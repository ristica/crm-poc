using Crm.Models.Contracts.BookDomain;

namespace Crm.Repository.Contracts;

public interface IBooksRepository
{
    IBook Get(int id);
    void UpdateOrCreate(IBook model);
    void Delete(int id);
    IEnumerable<IBook> GetAll();
}