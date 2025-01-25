using System.ComponentModel;
using Crm.Common.Contracts;
using Crm.Common.Shared;
using Crm.Dependencies.Contracts;
using Crm.Models.Contracts.MainDomain;
using Crm.Views.Contracts.Base;
using Crm.Views.Contracts.Views;

namespace Crm.Views;

public partial class FrmMain : Form, IFrmMain
{
    #region FIELDS

    private readonly IDependencyContainer _dependencyContainer;
    private readonly IEventHelper _eventHelper;
    private BindingList<IMainViewModel> _bindingList = new();

    #endregion

    #region PROPERTIES

    public string WindowTitle { get; set; }

    public IMainViewModel ViewModel { get; set; }

    public List<IBaseChildView> Children { get; set; } = new();

    #endregion

    #region EVENTS

    public event EventHandler FormLoadEventRaised;
    public event EventHandler FormCloseEventRaised;

    #endregion

    #region C-TOR

    public FrmMain(IDependencyContainer dependencyContainer)
    {
        _dependencyContainer = dependencyContainer;
        _eventHelper = dependencyContainer.Resolve<IEventHelper>();

        _bindingList.AllowEdit = true;
        _bindingList.AllowNew = true;
        _bindingList.AllowRemove = true;
        _bindingList.RaiseListChangedEvents = true;

        InitializeComponent();
        SetDataContext();
    }

    #endregion

    #region METHODS

    public void ShowView()
    {
        // intentionally left blank ...
    }

    public void MaximizeChild(IBaseChildView? child)
    {
        if (child == null) return;
        if (Children.SingleOrDefault(c => c.GetType() == child.GetType()) == null) return;
        MinimizeChildren(child);
        ((Form)child).WindowState = FormWindowState.Normal;
    }

    public void MinimizeChildren(IBaseChildView? childView = null)
    {
        foreach (var child in Children.Where(child => childView == null || child != childView))
            ((Form)child).WindowState = FormWindowState.Minimized;
    }

    #endregion

    #region HELPERS

    private void SetDataContext()
    {
        ViewModel = _dependencyContainer.Resolve<IMainViewModel>();
        ViewModel.CurrentRole = MenuRoleConstants.NoRole;
    }

    private void FrmMainOnLoad(object sender, EventArgs e)
    {
        _eventHelper.RaiseEvent(this, FormLoadEventRaised, e);
        InitializeBindings();
    }

    private void InitializeBindings()
    {
        UpdateBindings();

        // status bar
        lblCurrentRole.DataBindings.Add(
            BindingProperties.Text,
            _bindingList[0],
            nameof(IMainViewModel.CurrentRole),
            true,
            DataSourceUpdateMode.OnPropertyChanged);
        lblCurrentRole.DataBindings.Add(
            BindingProperties.ForeColor,
            _bindingList[0],
            nameof(IMainViewModel.CurrentRoleTextColor),
            true,
            DataSourceUpdateMode.OnPropertyChanged);

        // menu role
        menuRole_No.DataBindings.Add(
            BindingProperties.Command,
            _bindingList[0],
            nameof(IMainViewModel.RoleNoCommand),
            true, DataSourceUpdateMode.OnPropertyChanged);
        menuRole_Read.DataBindings.Add(
            BindingProperties.Command,
            _bindingList[0],
            nameof(IMainViewModel.RoleReadCommand),
            true,
            DataSourceUpdateMode.OnPropertyChanged);
        menuRole_ReadWrite.DataBindings.Add(
            BindingProperties.Command,
            _bindingList[0],
            nameof(IMainViewModel.RoleReadWriteCommand),
            true,
            DataSourceUpdateMode.OnPropertyChanged);
        menuRole_ReadWriteDelete.DataBindings.Add(
            BindingProperties.Command,
            _bindingList[0],
            nameof(IMainViewModel.RoleReadWriteDeleteCommand),
            true,
            DataSourceUpdateMode.OnPropertyChanged);

        // menu forms
        menuForms_Read.DataBindings.Add(
            BindingProperties.Command,
            _bindingList[0],
            nameof(IMainViewModel.OpenReadFormCommand),
            true,
            DataSourceUpdateMode.OnPropertyChanged);
        menuForms_ReadWrite.DataBindings.Add(
            BindingProperties.Command,
            _bindingList[0],
            nameof(IMainViewModel.OpenReadWriteFormCommand),
            true,
            DataSourceUpdateMode.OnPropertyChanged);
        menuForms_ReadWriteDelete.DataBindings.Add(
            BindingProperties.Command,
            _bindingList[0],
            nameof(IMainViewModel.OpenReadWriteDeleteFormCommand),
            true,
            DataSourceUpdateMode.OnPropertyChanged);
    }

    private void UpdateBindings()
    {
        _bindingList = new BindingList<IMainViewModel> { ViewModel };
    }

    private void FrmMainOnClosing(object sender, FormClosingEventArgs e)
    {
        _eventHelper.RaiseEvent(this, FormCloseEventRaised, e);
        Children.Clear();
        Children = null;
    }

    #endregion
}