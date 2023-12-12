using System.ComponentModel;
using System.Runtime.CompilerServices;
using Crm.Models.Contracts.Base;
using Crm.Models.Contracts.BookDomain;
using Crm.Views.Contracts.Base;
using Crm.Views.Contracts.Views;

namespace Crm.Views
{
    public partial class FrmAddBook : Form, IFrmAddBook
    {
        #region FIELDS

        private IBaseViewModel _viewModel;
        private BindingList<IAddBookViewModel> _bindingList = new();

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

        public FrmAddBook()
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

        #endregion

        #region HELPERS

        private void UpdateBindings()
        {
            this._bindingList = new() { this.ViewModel as IAddBookViewModel };
        }

        private void DoBindings()
        {
            this.UpdateBindings();

            // button
            this.btnSave.DataBindings.Add(
                "Command", 
                this._bindingList[0], 
                nameof(IAddBookViewModel.AddNewBookCommand),
                true,
                DataSourceUpdateMode.OnPropertyChanged);

            // text boxes
            this.txtIsbn.DataBindings.Add(
                "Visible", 
                this._bindingList[0], 
                nameof(IAddBookViewModel.IsReadWrite), 
                true, 
                DataSourceUpdateMode.OnPropertyChanged);
            this.txtIsbn.DataBindings.Add(
                "Text", 
                this._bindingList[0],
                "CurrentBook.Isbn",
                true, 
                DataSourceUpdateMode.OnPropertyChanged);

            this.txtTitle.DataBindings.Add(
                "Visible", 
                this._bindingList[0],
                nameof(IAddBookViewModel.IsReadWrite),
                true, DataSourceUpdateMode.OnPropertyChanged);
            this.txtTitle.DataBindings.Add(
                "Text",
                this._bindingList[0],
                "CurrentBook.Title",
                true, 
                DataSourceUpdateMode.OnPropertyChanged);

            this.txtAuthor.DataBindings.Add(
                "Visible",
                this._bindingList[0], 
                nameof(IAddBookViewModel.IsReadWrite), 
                true, 
                DataSourceUpdateMode.OnPropertyChanged);
            this.txtAuthor.DataBindings.Add(
                "Text",
                this._bindingList[0],
                "CurrentBook.Author",
                true,
                DataSourceUpdateMode.OnPropertyChanged);

            this.txtYear.DataBindings.Add(
                "Visible", 
                this._bindingList[0], 
                nameof(IAddBookViewModel.IsReadWrite),
                true,
                DataSourceUpdateMode.OnPropertyChanged);
            this.txtYear.DataBindings.Add(
                "Text",
                this._bindingList[0],
                "CurrentBook.PublishYear", 
                true, 
                DataSourceUpdateMode.OnPropertyChanged);
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
