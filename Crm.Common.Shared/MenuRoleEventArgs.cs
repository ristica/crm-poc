namespace Crm.Common.Shared;

public class MenuRoleEventArgs : EventArgs
{
    public string NewRole { get; private set; }

    public MenuRoleEventArgs(string newRole)
    {
        NewRole = newRole;
    }
}