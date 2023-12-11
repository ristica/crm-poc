using Crm.Models.BookDomain;
using Crm.Models.Contracts.BookDomain;

namespace Crm.Db
{
    public class Database
    {
        #region FIELDS

        private readonly List<Book> _books = new();

        private static Database _instance;
        private static readonly object Lock = new();

        #endregion

        #region PROPERTIES

        public static Database Instance
        {
            get
            {
                if (_instance != null) return _instance;

                lock (Lock)
                {
                    _instance = new Database();
                    return _instance;
                }
            }
        }

        #endregion

        #region C-TOR

        private Database()
        {
            this.CreateBookData();
        }

        #endregion

        #region BOOK CRUDs

        public void CreateBook(IBook model)
        {
            this._books.Add(new Book { Isbn = model.Isbn, Title = model.Title });
        }

        public void UpdateBook(IBook model)
        {
            var book = this._books.SingleOrDefault(b => b.Isbn.Equals(model.Isbn));
            if (book == null) return;

            book.Title = model.Title;
        }

        public IBook GetBookByIsbn(string isbn)
        {
            return this._books.SingleOrDefault(b => b.Isbn.Equals(isbn));
        }

        public IEnumerable<IBook> GetAllBooks()
        {
            return this._books;
        }

        public void DeleteBook(string isbn)
        {
            var book = this._books.SingleOrDefault(b => b.Isbn.Equals(isbn));
            if (book == null) return;
            this._books.Remove(book);
        }

        #endregion

        #region HELPERS

        private void CreateBookData()
        {
            this._books.Add(new Book { Isbn = "10000001", Title = "The free market and it's enemies", Author = "Ludwig von Mises", PublishYear = 1951 });
            this._books.Add(new Book { Isbn = "10000002", Title = "The road to serfdom", Author = "Friedrich A. von Hayek", PublishYear = 1944 });
            this._books.Add(new Book { Isbn = "10000003", Title = "The fountainhead", Author = "Ayn Rand", PublishYear = 1943 });
            this._books.Add(new Book { Isbn = "10000004", Title = "Free to choose", Author = "Milton Friedman", PublishYear = 1980 });
        }

        #endregion
    }
}
