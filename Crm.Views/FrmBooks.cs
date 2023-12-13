using Crm.Common.Shared;
using Crm.Models.Contracts.Base;
using Crm.Models.Contracts.BookDomain;
using Crm.Views.Contracts.Base;
using Crm.Views.Contracts.Views;
using System.ComponentModel;
using Crm.Views.Base;

namespace Crm.Views
{
    public partial class FrmBooks : FrmChildBase<IBookViewModel>, IFrmBooks
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

        public FrmBooks()
        {
            InitializeComponent();
        }

        #endregion

        #region METHODS

        public void LoadChildView()
        {
            base.DoLoadChildView(this.MdiContainerForm as Form);
        }

        public void UpdateBindings()
        {
            this.BindingList = new BindingList<IBookViewModel> { (IBookViewModel)this.ViewModel };
            this.lbBooks.DataSource = this.BindingList[0].Books;
        }

        protected override void DoBindings()
        {
            this.UpdateBindings();

            // list box
            this.lbBooks.DisplayMember = nameof(IBook.FriendlyOutput);
            this.lbBooks.ValueMember = nameof(IBook.Id);
            this.lbBooks.DataBindings.Add(
                BindingProperties.Visible,
                this.BindingList[0],
                nameof(IBookViewModel.IsRead),
                true,
                DataSourceUpdateMode.OnPropertyChanged);

            // text boxes
            this.txtIsbn.DataBindings.Add(
                BindingProperties.Visible,
                this.BindingList[0],
                nameof(IBookViewModel.IsRead),
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
                nameof(IBookViewModel.IsRead),
                true,
                DataSourceUpdateMode.OnPropertyChanged);
            this.txtTitle.DataBindings.Add(
                BindingProperties.Text,
                this.BindingList[0],
                "CurrentBook.Title",
                true, DataSourceUpdateMode.OnPropertyChanged);

            this.txtAuthor.DataBindings.Add(
                BindingProperties.Visible,
                this.BindingList[0],
                nameof(IBookViewModel.IsRead),
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
                nameof(IBookViewModel.IsRead),
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

        private void CurrentBookOnChanged(object sender, EventArgs e)
        {
            if (sender is not ListBox lb) return;

            var vm = (IBookViewModel)this.ViewModel;
            if (lb.SelectedItem == null) return;
            vm.CurrentBook = lb.SelectedItem as IBook;
        }

        #endregion
    }
}
