namespace Crm.Views.Contracts.Base
{
    public interface IBaseChildView
    {
        IBaseView MdiContainerForm { get; set; }
        void LoadChildView();
    }
}
