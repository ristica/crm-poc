using System.ComponentModel;
using Crm.Common.Contracts;
using Crm.Common.Shared;
using Crm.Dependencies.Contracts;
using Crm.Models.Contracts.MainDomain;
using Crm.Views.Contracts.Base;
using Crm.Views.Contracts.Views;

namespace Crm.Views
{
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

        public List<IBaseChildView> Children { get; set; }

        #endregion

        #region EVENTS

        public event EventHandler FormLoadEventRaised;
        public event EventHandler FormChildChangedEvent;

        public event EventHandler FormCloseEventRaised;

        #endregion

        #region  C-TOR

        public FrmMain(IDependencyContainer dependencyContainer)
        {
            this._dependencyContainer = dependencyContainer;
            this._eventHelper = dependencyContainer.Resolve<IEventHelper>();

            this.Children = new List<IBaseChildView>();

            this._bindingList.AllowEdit = true;
            this._bindingList.AllowNew = true;
            this._bindingList.AllowRemove = true;
            this._bindingList.RaiseListChangedEvents = true;

            InitializeComponent();
            this.SetDataContext();
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
            if (this.Children.SingleOrDefault(c => c.GetType() == child.GetType()) == null) return;

            ((Form)child).WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region HELPERS

        private void SetDataContext()
        {
            this.ViewModel = this._dependencyContainer.Resolve<IMainViewModel>();
            this.ViewModel.CurrentRole = MenuRoleConstants.NoRole;
        }

        private void FrmMainOnLoad(object sender, EventArgs e)
        {
            this._eventHelper.RaiseEvent(this, FormLoadEventRaised, e);
            this.InitializeBindings();
        }

        private void InitializeBindings()
        {
            this.UpdateBindings();

            // status bar
            this.lblCurrentRole.DataBindings.Add("Text", this._bindingList[0], "CurrentRole", true, DataSourceUpdateMode.OnPropertyChanged);
            this.lblCurrentRole.DataBindings.Add("ForeColor", this._bindingList[0], "CurrentRoleTextColor", true, DataSourceUpdateMode.OnPropertyChanged);

            // menu role
            this.menuRole_No.DataBindings.Add("Command", this._bindingList[0], "RoleNoCommand", true, DataSourceUpdateMode.OnPropertyChanged);
            this.menuRole_Read.DataBindings.Add("Command", this._bindingList[0], "RoleReadCommand", true, DataSourceUpdateMode.OnPropertyChanged);
            this.menuRole_ReadWrite.DataBindings.Add("Command", this._bindingList[0], "RoleReadWriteCommand", true, DataSourceUpdateMode.OnPropertyChanged);
            this.menuRole_ReadWriteDelete.DataBindings.Add("Command", this._bindingList[0], "RoleReadWriteDeleteCommand", true, DataSourceUpdateMode.OnPropertyChanged);

            // menu forms
            this.menuForms_Read.DataBindings.Add("Command", this._bindingList[0], "OpenReadFormCommand", true, DataSourceUpdateMode.OnPropertyChanged);
            //this.menuForms_Read.DataBindings.Add("Enabled", this._bindingList[0], "IsRead", true, DataSourceUpdateMode.OnPropertyChanged);
            this.menuForms_ReadWrite.DataBindings.Add("Command", this._bindingList[0], "OpenReadWriteFormCommand", true, DataSourceUpdateMode.OnPropertyChanged);
            //this.menuForms_ReadWrite.DataBindings.Add("Enabled", this._bindingList[0], "IsReadWrite", true, DataSourceUpdateMode.OnPropertyChanged);
            this.menuForms_ReadWriteDelete.DataBindings.Add("Command", this._bindingList[0], "OpenReadWriteDeleteFormCommand", true, DataSourceUpdateMode.OnPropertyChanged);
            //this.menuForms_ReadWriteDelete.DataBindings.Add("Enabled", this._bindingList[0], "IsReadWriteDelete", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void UpdateBindings()
        {
            this._bindingList = new() { this.ViewModel };
        }

        private void FrmMainOnClosing(object sender, FormClosingEventArgs e)
        {
            this._eventHelper.RaiseEvent(this, FormCloseEventRaised, e);
            this.Children.Clear();
            this.Children = null;
        }

        private void FormOnChanged(object sender, EventArgs e)
        {
            //if (sender == null) return;

            //foreach (var child in this.Children)
            //{
            //    ((Form)child).WindowState = FormWindowState.Minimized;
            //}

            //var newForm = MapMenuToConstant(sender.ToString());
            //this._eventHelper.RaiseEvent(this, FormChildChangedEvent, new RoleAndFormEventArgs(newForm));
        }

        private string MapMenuToConstant(string menu)
        {
            if (menu.ToLowerInvariant().StartsWith("no")) return MenuRoleConstants.NoRole;
            if (menu.ToLowerInvariant().Contains("delete")) return MenuRoleConstants.ReadWriteDelete;
            if (menu.ToLowerInvariant().Contains("write")) return MenuRoleConstants.ReadWrite;
            return menu.ToLowerInvariant().Contains("read") ? MenuRoleConstants.Read : MenuRoleConstants.NoRole;
        }

        #endregion
    }
}
