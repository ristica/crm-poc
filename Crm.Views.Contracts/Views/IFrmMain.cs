using Crm.Models.Contracts.MainDomain;
using Crm.Views.Contracts.Base;

namespace Crm.Views.Contracts.Views
{
    public interface IFrmMain : IBaseView
    {
        IMainViewModel ViewModel { get; set; }
        List<IBaseChildView> Children { get; set; }
        void MaximizeChild(IBaseChildView? child);
        void MinimizeChildren(IBaseChildView? childView = null);
    }
}