using Crm.Views.Contracts.Base;

namespace Crm.Presenters.Contracts.Base;

public interface IBaseViewPresenter : IDisposable
{
    IBaseView GetView();
    void ShowView();
}