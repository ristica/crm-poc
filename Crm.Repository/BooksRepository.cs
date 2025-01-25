using Crm.Db;
using Crm.Models.Contracts.BookDomain;
using Crm.Repository.Contracts;

namespace Crm.Repository;

public class BooksRepository : IBooksRepository
{
    public IBook Get(int id)
    {
        return Database.Instance.GetBookById(id);
    }

    public void UpdateOrCreate(IBook model)
    {
        if (model.Id < 1) Create(model);
        else Update(model);
    }

    public void Delete(int id)
    {
        Database.Instance.DeleteBook(id);
    }

    public IEnumerable<IBook> GetAll()
    {
        return Database.Instance.GetAllBooks();
    }

    private void Update(IBook model)
    {
        Database.Instance.UpdateBook(model);
    }

    private void Create(IBook model)
    {
        Database.Instance.CreateBook(model);
    }
}