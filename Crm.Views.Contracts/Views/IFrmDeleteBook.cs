using Crm.Views.Contracts.Base;
using System.ComponentModel;

namespace Crm.Views.Contracts.Views
{
    public interface IFrmDeleteBook : IBaseChildView, INotifyPropertyChanged
    {
        void UpdateBindings();
    }
}
