using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Crm.Views.Base
{
    public abstract class FrmBase<T> : Form
    {
        protected BindingList<T> BindingList = new();

        protected FrmBase()
        {
            this.BindingList.AllowEdit = true;
            this.BindingList.AllowNew = true;
            this.BindingList.AllowRemove = true;
            this.BindingList.RaiseListChangedEvents = true;
        }

        protected virtual void DoLoadChildView(Form mdi)
        {
            this.DoBindings();
            this.MdiParent = mdi;
            this.Dock = DockStyle.Fill;
            this.Show();
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
}
