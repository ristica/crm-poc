using Crm.Models.Contracts.BookDomain;
using Crm.Repository.Contracts;
using Crm.Services.Contracts;

namespace Crm.Services
{
    public class BooksService<T> : IBooksService<IBook> where T : class
    {
        private readonly IBooksRepository _booksRepository;

        public BooksService(IBooksRepository booksRepository)
        {
            this._booksRepository = booksRepository;
        }

        public void ValidateModelDataAnnotations(IBook model)
        {

        }

        public IBook Get(int id)
        {
            return this._booksRepository.Get(id);
        }

        public void UpdateOrCreate(IBook model)
        {
            this._booksRepository.UpdateOrCreate(model);
        }

        public void Delete(int id)
        {
            this._booksRepository.Delete(id);
        }

        public IEnumerable<IBook> GetAll()
        {
            return this._booksRepository.GetAll();
        }
    }
}
