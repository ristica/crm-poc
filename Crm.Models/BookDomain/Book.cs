using Crm.Common.NotificationBase;
using Crm.Models.Contracts.BookDomain;

namespace Crm.Models.BookDomain;

public class Book : CommonBase, IBook
{
    private int _id;
    private string _isbn = string.Empty;
    private string _title = string.Empty;
    private string _author = string.Empty;
    private int _publishYear;

    public int Id
    {
        get => _id;
        set
        {
            _id = value;
            OnPropertyChanged();
        }
    }

    public string Isbn
    {
        get => _isbn;
        set
        {
            if (string.IsNullOrEmpty(value) || _isbn.Equals(value)) return;
            _isbn = value;
            OnPropertyChanged();
        }
    }

    public string Title
    {
        get => _title;
        set
        {
            if (string.IsNullOrEmpty(value) || _title.Equals(value)) return;
            _title = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(FriendlyOutput));
        }
    }

    public string Author
    {
        get => _author;
        set
        {
            if (string.IsNullOrEmpty(value) || _author.Equals(value)) return;
            _author = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(FriendlyOutput));
        }
    }

    public int PublishYear
    {
        get => _publishYear;
        set
        {
            _publishYear = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(FriendlyOutput));
        }
    }

    public string FriendlyOutput => $"\"{Title}\" by {Author}";
}