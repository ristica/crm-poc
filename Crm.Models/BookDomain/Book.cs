using Crm.Common.NotificationBase;
using Crm.Models.Contracts.BookDomain;

namespace Crm.Models.BookDomain
{
    public class Book : CommonBase, IBook
    {
        private int _id;
        private string _isbn = string.Empty;
        private string _title = string.Empty;
        private string _author = string.Empty;
        private int _publishYear;

        public int Id
        {
            get => this._id;
            set
            {
                this._id = value;
                OnPropertyChanged();
            }
        }

        public string Isbn
        {
            get => this._isbn;
            set
            {
                if (string.IsNullOrEmpty(value) || this._isbn.Equals(value)) return;
                this._isbn = value;
                OnPropertyChanged();
            }
        }

        public string Title
        {
            get => this._title;
            set
            {
                if (string.IsNullOrEmpty(value) || this._title.Equals(value)) return;
                this._title = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(this.FriendlyOutput));
            }
        }

        public string Author
        {
            get => this._author;
            set
            {
                if (string.IsNullOrEmpty(value) || this._author.Equals(value)) return;
                this._author = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(this.FriendlyOutput));
            }
        }

        public int PublishYear
        {
            get => this._publishYear;
            set
            {
                this._publishYear = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(this.FriendlyOutput));
            }
        }

        public string FriendlyOutput => $"\"{this.Title}\" by {this.Author}";
    }
}
