using Crm.Views.Contracts.Base;

namespace Crm.Presenters.Contracts.Base
{
    public interface IBaseChildViewPresenter : IDisposable
    {
        IBaseChildView GetView();
        void ShowView(IBaseView mdiContainerForm);
    }
}
