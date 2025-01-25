using Crm.Models.Contracts.BookDomain;

namespace Crm.Common.Shared;

public class AddBookEventArgs : EventArgs
{
    public IBook NewBook { get; private set; }

    public AddBookEventArgs(IBook book)
    {
        NewBook = book;
    }
}