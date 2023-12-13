using Crm.Common.Shared;
using Crm.Models.Contracts.Base;
using Crm.Models.Contracts.BookDomain;
using Crm.Views.Contracts.Base;
using Crm.Views.Contracts.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Crm.Views
{
    public partial class FrmBooks : Form, IFrmBooks
    {
        #region FIELDS

        private IBaseViewModel _viewModel;
        private BindingList<IBookViewModel> _bindingList = new();

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

        public FrmBooks()
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
            this._bindingList = new BindingList<IBookViewModel> { (IBookViewModel)this.ViewModel };
            this.lbBooks.DataSource = this._bindingList[0].Books;
        }

        #endregion

        #region HELPERS

        private void DoBindings()
        {
            this.UpdateBindings();

            // list box
            this.lbBooks.DisplayMember = nameof(IBook.FriendlyOutput);
            this.lbBooks.ValueMember = nameof(IBook.Id);
            this.lbBooks.DataBindings.Add(
                BindingProperties.Visible,
                this._bindingList[0], 
                nameof(IBookViewModel.IsRead), 
                true, 
                DataSourceUpdateMode.OnPropertyChanged);

            // text boxes
            this.txtIsbn.DataBindings.Add(
                BindingProperties.Visible,
                this._bindingList[0],
                nameof(IBookViewModel.IsRead),
                true,
                DataSourceUpdateMode.OnPropertyChanged);
            this.txtIsbn.DataBindings.Add(
                BindingProperties.Text, 
                this._bindingList[0], 
                "CurrentBook.Isbn", 
                true,
                DataSourceUpdateMode.OnPropertyChanged);

            this.txtTitle.DataBindings.Add(
                BindingProperties.Visible,
                this._bindingList[0], 
                nameof(IBookViewModel.IsRead), 
                true,
                DataSourceUpdateMode.OnPropertyChanged);
            this.txtTitle.DataBindings.Add(
                BindingProperties.Text, 
                this._bindingList[0], 
                "CurrentBook.Title",
                true, DataSourceUpdateMode.OnPropertyChanged);

            this.txtAuthor.DataBindings.Add(
                BindingProperties.Visible, 
                this._bindingList[0],
                nameof(IBookViewModel.IsRead),
                true,
                DataSourceUpdateMode.OnPropertyChanged);
            this.txtAuthor.DataBindings.Add(
                BindingProperties.Text, 
                this._bindingList[0], 
                "CurrentBook.Author", 
                true, 
                DataSourceUpdateMode.OnPropertyChanged);

            this.txtYear.DataBindings.Add(
                BindingProperties.Visible, 
                this._bindingList[0],
                nameof(IBookViewModel.IsRead), 
                true,
                DataSourceUpdateMode.OnPropertyChanged);
            this.txtYear.DataBindings.Add(
                BindingProperties.Text,
                this._bindingList[0], 
                "CurrentBook.PublishYear", 
                true, 
                DataSourceUpdateMode.OnPropertyChanged);
        }

        private void CurrentBookOnChanged(object sender, EventArgs e)
        {
            if (sender is not ListBox lb) return;

            var vm = (IBookViewModel)this.ViewModel;
            if (lb.SelectedItem == null) return;
            vm.CurrentBook = lb.SelectedItem as IBook;
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
