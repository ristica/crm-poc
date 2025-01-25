using Crm.Common.Shared;
using Crm.Models.Contracts.Base;
using Crm.Models.Contracts.BookDomain;
using Crm.Views.Contracts.Base;
using Crm.Views.Contracts.Views;
using System.ComponentModel;
using Crm.Views.Base;

namespace Crm.Views;

public partial class FrmBooks : FrmChildBase<IBookViewModel>, IFrmBooks
{
    #region FIELDS

    private IBaseViewModel _viewModel;

    #endregion

    #region PROPERTIES

    public IBaseViewModel ViewModel
    {
        get => _viewModel;
        set
        {
            _viewModel = value;
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
        base.DoLoadChildView(MdiContainerForm as Form);
    }

    public void UpdateBindings()
    {
        BindingList = new BindingList<IBookViewModel> { (IBookViewModel)ViewModel };
        lbBooks.DataSource = BindingList[0].Books;
    }

    protected override void DoBindings()
    {
        UpdateBindings();

        // list box
        lbBooks.DisplayMember = nameof(IBook.FriendlyOutput);
        lbBooks.ValueMember = nameof(IBook.Id);
        lbBooks.DataBindings.Add(
            BindingProperties.Visible,
            BindingList[0],
            nameof(IBookViewModel.IsRead),
            true,
            DataSourceUpdateMode.OnPropertyChanged);

        // text boxes
        txtIsbn.DataBindings.Add(
            BindingProperties.Visible,
            BindingList[0],
            nameof(IBookViewModel.IsRead),
            true,
            DataSourceUpdateMode.OnPropertyChanged);
        txtIsbn.DataBindings.Add(
            BindingProperties.Text,
            BindingList[0],
            "CurrentBook.Isbn",
            true,
            DataSourceUpdateMode.OnPropertyChanged);

        txtTitle.DataBindings.Add(
            BindingProperties.Visible,
            BindingList[0],
            nameof(IBookViewModel.IsRead),
            true,
            DataSourceUpdateMode.OnPropertyChanged);
        txtTitle.DataBindings.Add(
            BindingProperties.Text,
            BindingList[0],
            "CurrentBook.Title",
            true, DataSourceUpdateMode.OnPropertyChanged);

        txtAuthor.DataBindings.Add(
            BindingProperties.Visible,
            BindingList[0],
            nameof(IBookViewModel.IsRead),
            true,
            DataSourceUpdateMode.OnPropertyChanged);
        txtAuthor.DataBindings.Add(
            BindingProperties.Text,
            BindingList[0],
            "CurrentBook.Author",
            true,
            DataSourceUpdateMode.OnPropertyChanged);

        txtYear.DataBindings.Add(
            BindingProperties.Visible,
            BindingList[0],
            nameof(IBookViewModel.IsRead),
            true,
            DataSourceUpdateMode.OnPropertyChanged);
        txtYear.DataBindings.Add(
            BindingProperties.Text,
            BindingList[0],
            "CurrentBook.PublishYear",
            true,
            DataSourceUpdateMode.OnPropertyChanged);
    }

    #endregion

    #region HELPERS

    private void CurrentBookOnChanged(object sender, EventArgs e)
    {
        if (sender is not ListBox lb) return;

        var vm = (IBookViewModel)ViewModel;
        if (lb.SelectedItem == null) return;
        vm.CurrentBook = lb.SelectedItem as IBook;
    }

    #endregion
}