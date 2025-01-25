namespace Crm.Common.Shared;

public class DeleteBookEventArgs : EventArgs
{
    public int Id { get; private set; }

    public DeleteBookEventArgs(int id)
    {
        Id = id;
    }
}