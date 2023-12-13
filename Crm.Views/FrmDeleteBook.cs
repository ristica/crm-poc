using System.ComponentModel;
using System.Runtime.CompilerServices;
using Crm.Models.Contracts.Base;
using Crm.Models.Contracts.BookDomain;
using Crm.Views.Contracts.Base;
using Crm.Views.Contracts.Views;

namespace Crm.Views
{
    public partial class FrmDeleteBook : Form, IFrmDeleteBook
    {
        #region FIELDS

        private IBaseViewModel _viewModel;
        private BindingList<IDeleteBookViewModel> _bindingList = new();

        #endregion

        #region PROPERTIES

        public IBaseViewModel ViewModel
        {
            get => this._viewModel;
            set
            {
                this._viewModel = value;
                OnPropertyChanged();
            }
        }

        public IBaseView MdiContainerForm { get; set; }

        #endregion

        #region C-TOR

        public FrmDeleteBook()
        {
            InitializeComponent();

            this._bindingList.AllowEdit = true;
            this._bindingList.AllowNew = true;
            this._bindingList.AllowRemove = true;
            this._bindingList.RaiseListChangedEvents = true;
        }

        #endregion

        #region METHODS

        public void LoadChildView()
        {
            this.DoBindings();
            this.MdiParent = this.MdiContainerForm as Form;
            this.Dock = DockStyle.Fill;
            this.Show();
        }
        public void UpdateBindings()
        {
            this._bindingList = new() { (IDeleteBookViewModel)this.ViewModel };
            this.cbBooks.DataSource = this._bindingList[0].Books;
        }

        #endregion

        #region HELPERS

        private void DoBindings()
        {
            this.UpdateBindings();

            // combo box
            this.cbBooks.DisplayMember = nameof(IBook.Title);
            this.cbBooks.ValueMember = nameof(IBook.Id);
            this.cbBooks.DataBindings.Add(
                "Visible",
                this._bindingList[0],
                nameof(IDeleteBookViewModel.IsReadWriteDelete),
                true,
                DataSourceUpdateMode.OnPropertyChanged);

            // button
            this.btnDelete.DataBindings.Add(
                "Command",
                this._bindingList[0],
                nameof(IDeleteBookViewModel.DeleteBookCommand),
                true,
                DataSourceUpdateMode.OnPropertyChanged);
        }

        private void BookToDeleteOnSelected(object sender, EventArgs e)
        {
            if (sender is not ComboBox cb) return;

            var vm = (IDeleteBookViewModel)this.ViewModel;
            if (cb.SelectedItem == null) return;
            vm.CurrentBook = cb.SelectedItem as IBook;
        }

        #endregion

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
