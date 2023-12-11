using Crm.Common.Utility;
using Crm.Models.Contracts.Base;

namespace Crm.Models.Contracts.MainDomain
{
    public interface IMainViewModel : IBaseViewModel
    {
        RelayCommand RoleNoCommand { get; }
        RelayCommand RoleReadCommand { get; }
        RelayCommand RoleReadWriteCommand { get; }
        RelayCommand RoleReadWriteDeleteCommand { get; }
        RelayCommand OpenReadFormCommand { get; }
        RelayCommand OpenReadWriteFormCommand { get; }
        RelayCommand OpenReadWriteDeleteFormCommand { get; }
    }
}
