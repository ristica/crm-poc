using System.Drawing;

namespace Crm.Models.Contracts.Base
{
    public interface IBaseViewModel
    {
        string CurrentRole { get; set; }
        bool IsRead { get; }
        bool IsReadWrite { get; }
        bool IsReadWriteDelete { get; }
        Color CurrentRoleTextColor { get; }
    }
}
