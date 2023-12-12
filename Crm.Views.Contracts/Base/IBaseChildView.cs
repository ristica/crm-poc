using Crm.Models.Contracts.Base;

namespace Crm.Views.Contracts.Base
{
    public interface IBaseChildView
    {
        IBaseViewModel ViewModel { get; set; }
        IBaseView MdiContainerForm { get; set; }
        void LoadChildView();
    }
}
