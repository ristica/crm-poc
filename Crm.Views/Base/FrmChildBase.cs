using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Crm.Views.Base;

public abstract class FrmChildBase<T> : Form
{
    protected BindingList<T> BindingList = new();

    protected FrmChildBase()
    {
        BindingList.AllowEdit = true;
        BindingList.AllowNew = true;
        BindingList.AllowRemove = true;
        BindingList.RaiseListChangedEvents = true;
    }

    protected virtual void DoLoadChildView(Form mdi)
    {
        DoBindings();
        MdiParent = mdi;
        Dock = DockStyle.Fill;
        Show();
    }

    protected abstract void DoBindings();

    #region INotifyPropertyChanged

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    #endregion
}