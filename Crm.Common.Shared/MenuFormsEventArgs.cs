namespace Crm.Common.Shared
{
    public class MenuFormsEventArgs : EventArgs
    {
        public string NewForm { get; private set; }

        public MenuFormsEventArgs(string newRole)
        {
            this.NewForm = newRole;
        }
    }
}
