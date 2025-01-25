using System.ComponentModel;
using Crm.Views.Contracts.Base;

namespace Crm.Views.Contracts.Views;

public interface IFrmBooks : IBaseChildView, INotifyPropertyChanged
{
    void UpdateBindings();
}