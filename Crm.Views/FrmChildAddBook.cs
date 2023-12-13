using Crm.Common.Shared;
using Crm.Models.Contracts.Base;
using Crm.Models.Contracts.BookDomain;
using Crm.Views.Base;
using Crm.Views.Contracts.Base;
using Crm.Views.Contracts.Views;

namespace Crm.Views
{
    public partial class FrmChildAddBook : FrmChildBase<IAddBookViewModel>, IFrmAddBook
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

        public FrmChildAddBook()
        {
            InitializeComponent();
        }

        #endregion

        #region METHODS

        public void LoadChildView()
        {
            base.DoLoadChildView(this.MdiContainerForm as Form);
        }
        protected override void DoBindings()
        {
            this.UpdateBindings();

            // button
            this.btnSave.DataBindings.Add(
                BindingProperties.Command,
                this.BindingList[0],
                nameof(IAddBookViewModel.AddNewBookCommand),
                true,
                DataSourceUpdateMode.OnPropertyChanged);

            // text boxes
            this.txtIsbn.DataBindings.Add(
                BindingProperties.Visible,
                this.BindingList[0],
                nameof(IAddBookViewModel.IsReadWrite),
                true,
                DataSourceUpdateMode.OnPropertyChanged);
            this.txtIsbn.DataBindings.Add(
                BindingProperties.Text,
                this.BindingList[0],
                "CurrentBook.Isbn",
                true,
                DataSourceUpdateMode.OnPropertyChanged);

            this.txtTitle.DataBindings.Add(
                BindingProperties.Visible,
                this.BindingList[0],
                nameof(IAddBookViewModel.IsReadWrite),
                true, DataSourceUpdateMode.OnPropertyChanged);
            this.txtTitle.DataBindings.Add(
                BindingProperties.Text,
                this.BindingList[0],
                "CurrentBook.Title",
                true,
                DataSourceUpdateMode.OnPropertyChanged);

            this.txtAuthor.DataBindings.Add(
                BindingProperties.Visible,
                this.BindingList[0],
                nameof(IAddBookViewModel.IsReadWrite),
                true,
                DataSourceUpdateMode.OnPropertyChanged);
            this.txtAuthor.DataBindings.Add(
                BindingProperties.Text,
                this.BindingList[0],
                "CurrentBook.Author",
                true,
                DataSourceUpdateMode.OnPropertyChanged);

            this.txtYear.DataBindings.Add(
                BindingProperties.Visible,
                this.BindingList[0],
                nameof(IAddBookViewModel.IsReadWrite),
                true,
                DataSourceUpdateMode.OnPropertyChanged);
            this.txtYear.DataBindings.Add(
                BindingProperties.Text,
                this.BindingList[0],
                "CurrentBook.PublishYear",
                true,
                DataSourceUpdateMode.OnPropertyChanged);
        }

        #endregion

        #region HELPERS

        private void UpdateBindings()
        {
            this.BindingList = new() { (IAddBookViewModel)this.ViewModel };
        }

        #endregion
    }
}
