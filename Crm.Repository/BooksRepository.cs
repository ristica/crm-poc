using Crm.Db;
using Crm.Models.Contracts.BookDomain;
using Crm.Repository.Contracts;

namespace Crm.Repository
{
    public class BooksRepository : IBooksRepository
    {
        public IBook Get(string isbn)
        {
            return Database.Instance.GetBookByIsbn(isbn);
        }

        public void UpdateOrCreate(IBook model)
        {
            if (string.IsNullOrEmpty(model.Isbn)) this.Create(model);
            else this.Update(model);
        }

        public void Delete(string isbn)
        {
            Database.Instance.DeleteBook(isbn);
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
}
