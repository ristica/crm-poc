using System.ComponentModel;
using Crm.Models.Contracts.BookDomain;
using Crm.Views.Contracts.Base;

namespace Crm.Views.Contracts.Views
{
    public interface IFrmBooks : IBaseChildView, INotifyPropertyChanged
    {
        void UpdateBindings();
    }
}
