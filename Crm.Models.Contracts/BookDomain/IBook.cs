namespace Crm.Models.Contracts.BookDomain
{
    public interface IBook
    {
        string Isbn { get; set; }
        string Title { get; set; }
        string Author { get; set; }
        int? PublishYear { get; set; }
        string FriendlyOutput { get; }
    }
}
