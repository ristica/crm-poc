using Crm.Common.Shared;
using Crm.Models.Contracts.Base;
using Crm.Models.Contracts.BookDomain;
using Crm.Views.Base;
using Crm.Views.Contracts.Base;
using Crm.Views.Contracts.Views;

namespace Crm.Views
{
    public partial class FrmDeleteBook : FrmChildBase<IDeleteBookViewModel>, IFrmDeleteBook
    {
        #region FIELDS

        private IBaseViewModel _viewModel;

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

            this.BindingList.AllowEdit = true;
            this.BindingList.AllowNew = true;
            this.BindingList.AllowRemove = true;
            this.BindingList.RaiseListChangedEvents = true;
        }

        #endregion

        #region METHODS

        public void LoadChildView()
        {
            base.DoLoadChildView(this.MdiContainerForm as Form);
        }

        public void UpdateBindings()
        {
            this.BindingList = new() { (IDeleteBookViewModel)this.ViewModel };
            this.cbBooks.DataSource = this.BindingList[0].Books;
        }

        protected override void DoBindings()
        {
            this.UpdateBindings();

            // combo box
            this.cbBooks.DisplayMember = nameof(IBook.Title);
            this.cbBooks.ValueMember = nameof(IBook.Id);
            this.cbBooks.DataBindings.Add(
                BindingProperties.Visible,
                this.BindingList[0],
                nameof(IDeleteBookViewModel.IsReadWriteDelete),
                true,
                DataSourceUpdateMode.OnPropertyChanged);

            // button
            this.btnDelete.DataBindings.Add(
                BindingProperties.Command,
                this.BindingList[0],
                nameof(IDeleteBookViewModel.DeleteBookCommand),
                true,
                DataSourceUpdateMode.OnPropertyChanged);
        }

        #endregion

        #region HELPERS

        private void BookToDeleteOnSelected(object sender, EventArgs e)
        {
            if (sender is not ComboBox cb) return;

            var vm = (IDeleteBookViewModel)this.ViewModel;
            if (cb.SelectedItem == null) return;
            vm.CurrentBook = cb.SelectedItem as IBook;
        }

        #endregion
    }
}
