using System.ComponentModel;
using Crm.Common.Shared;
using Crm.Models.Contracts.Base;
using Crm.Models.Contracts.BookDomain;
using Crm.Views.Base;
using Crm.Views.Contracts.Base;
using Crm.Views.Contracts.Views;

namespace Crm.Views;

public partial class FrmDeleteBook : FrmChildBase<IDeleteBookViewModel>, IFrmDeleteBook
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

    public FrmDeleteBook()
    {
        InitializeComponent();

        BindingList.AllowEdit = true;
        BindingList.AllowNew = true;
        BindingList.AllowRemove = true;
        BindingList.RaiseListChangedEvents = true;
    }

    #endregion

    #region METHODS

    public void LoadChildView()
    {
        base.DoLoadChildView(MdiContainerForm as Form);
    }

    public void UpdateBindings()
    {
        BindingList = new BindingList<IDeleteBookViewModel> { (IDeleteBookViewModel)ViewModel };
        cbBooks.DataSource = BindingList[0].Books;
    }

    protected override void DoBindings()
    {
        UpdateBindings();

        // combo box
        cbBooks.DisplayMember = nameof(IBook.Title);
        cbBooks.ValueMember = nameof(IBook.Id);
        cbBooks.DataBindings.Add(
            BindingProperties.Visible,
            BindingList[0],
            nameof(IDeleteBookViewModel.IsReadWriteDelete),
            true,
            DataSourceUpdateMode.OnPropertyChanged);

        // button
        btnDelete.DataBindings.Add(
            BindingProperties.Command,
            BindingList[0],
            nameof(IDeleteBookViewModel.DeleteBookCommand),
            true,
            DataSourceUpdateMode.OnPropertyChanged);
    }

    #endregion

    #region HELPERS

    private void BookToDeleteOnSelected(object sender, EventArgs e)
    {
        if (sender is not ComboBox cb) return;

        var vm = (IDeleteBookViewModel)ViewModel;
        if (cb.SelectedItem == null) return;
        vm.CurrentBook = cb.SelectedItem as IBook;
    }

    #endregion
}