using System.ComponentModel;
using Crm.Common.Shared;
using Crm.Models.Contracts.Base;
using Crm.Models.Contracts.BookDomain;
using Crm.Views.Base;
using Crm.Views.Contracts.Base;
using Crm.Views.Contracts.Views;

namespace Crm.Views;

public partial class FrmAddBook : FrmChildBase<IAddBookViewModel>, IFrmAddBook
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

    public FrmAddBook()
    {
        InitializeComponent();
    }

    #endregion

    #region METHODS

    public void LoadChildView()
    {
        base.DoLoadChildView(MdiContainerForm as Form);
    }

    protected override void DoBindings()
    {
        UpdateBindings();

        // button
        btnSave.DataBindings.Add(
            BindingProperties.Command,
            BindingList[0],
            nameof(IAddBookViewModel.AddNewBookCommand),
            true,
            DataSourceUpdateMode.OnPropertyChanged);

        // text boxes
        txtIsbn.DataBindings.Add(
            BindingProperties.Visible,
            BindingList[0],
            nameof(IAddBookViewModel.IsReadWrite),
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
            nameof(IAddBookViewModel.IsReadWrite),
            true, DataSourceUpdateMode.OnPropertyChanged);
        txtTitle.DataBindings.Add(
            BindingProperties.Text,
            BindingList[0],
            "CurrentBook.Title",
            true,
            DataSourceUpdateMode.OnPropertyChanged);

        txtAuthor.DataBindings.Add(
            BindingProperties.Visible,
            BindingList[0],
            nameof(IAddBookViewModel.IsReadWrite),
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
            nameof(IAddBookViewModel.IsReadWrite),
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

    private void UpdateBindings()
    {
        BindingList = new BindingList<IAddBookViewModel> { (IAddBookViewModel)ViewModel };
    }

    #endregion
}