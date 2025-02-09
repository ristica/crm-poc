﻿using Crm.Models.BookDomain;
using Crm.Models.Contracts.BookDomain;

namespace Crm.Db;

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
        CreateBookData();
    }

    #endregion

    #region BOOK CRUDs

    public void CreateBook(IBook model)
    {
        _books.Add(new Book
        {
            Id = GetNewId(), Isbn = model.Isbn, Title = model.Title, Author = model.Author,
            PublishYear = model.PublishYear
        });
    }

    private int GetNewId()
    {
        return _books.Max(b => b.Id) + 1;
    }

    public void UpdateBook(IBook model)
    {
        var book = _books.SingleOrDefault(b => b.Isbn.Equals(model.Isbn));
        if (book == null) return;

        book.Title = model.Title;
        book.Author = model.Author;
        book.PublishYear = model.PublishYear;
        book.Isbn = model.Isbn;
    }

    public IBook GetBookById(int id)
    {
        return _books.SingleOrDefault(b => b.Id == id);
    }

    public IEnumerable<IBook> GetAllBooks()
    {
        return _books;
    }

    public void DeleteBook(int id)
    {
        var book = _books.SingleOrDefault(b => b.Id == id);
        if (book == null) return;
        _books.Remove(book);
    }

    #endregion

    #region HELPERS

    private void CreateBookData()
    {
        _books.Add(new Book
        {
            Id = 1, Isbn = "10000001", Title = "The free market and it's enemies", Author = "Ludwig von Mises",
            PublishYear = 1951
        });
        _books.Add(new Book
        {
            Id = 2, Isbn = "10000002", Title = "The road to serfdom", Author = "Friedrich A. von Hayek",
            PublishYear = 1944
        });
        _books.Add(new Book
            { Id = 3, Isbn = "10000003", Title = "The fountainhead", Author = "Ayn Rand", PublishYear = 1943 });
        _books.Add(new Book
            { Id = 4, Isbn = "10000004", Title = "Free to choose", Author = "Milton Friedman", PublishYear = 1980 });
    }

    #endregion
}