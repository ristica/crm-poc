﻿using Crm.Models.Contracts.BookDomain;
using Crm.Views.Contracts.Base;
using Crm.Views.Contracts.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Crm.Views
{
    public partial class FrmBooks : Form, IFrmBooks
    {
        #region FIELDS

        private IBookViewModel _viewModel;
        private BindingList<IBookViewModel> _bindingList = new();

        #endregion

        #region PROPERTIES

        public IBookViewModel ViewModel
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

        #endregion

        #region HELPERS

        private void UpdateBindings()
        {
            this._bindingList = new BindingList<IBookViewModel>
            {
                this.ViewModel
            };
        }

        private void DoBindings()
        {
            this.UpdateBindings();

            // list box
            this.lbBooks.DataSource = this._bindingList[0].Books;
            this.lbBooks.DisplayMember = "FriendlyOutput";
            this.lbBooks.ValueMember = "Isbn";
            this.lbBooks.DataBindings.Add("Visible", this._bindingList[0], "IsRead", true, DataSourceUpdateMode.OnPropertyChanged);

            // text boxes
            this.txtIsbn.DataBindings.Add("Visible", this._bindingList[0], "IsRead", true, DataSourceUpdateMode.OnPropertyChanged);
            this.txtIsbn.DataBindings.Add("Text", this._bindingList[0], "CurrentBook.Isbn", true, DataSourceUpdateMode.OnPropertyChanged);

            this.txtTitle.DataBindings.Add("Visible", this._bindingList[0], "IsRead", true, DataSourceUpdateMode.OnPropertyChanged);
            this.txtTitle.DataBindings.Add("Text", this._bindingList[0], "CurrentBook.Title", true, DataSourceUpdateMode.OnPropertyChanged);

            this.txtAuthor.DataBindings.Add("Visible", this._bindingList[0], "IsRead", true, DataSourceUpdateMode.OnPropertyChanged);
            this.txtAuthor.DataBindings.Add("Text", this._bindingList[0], "CurrentBook.Author", true, DataSourceUpdateMode.OnPropertyChanged);

            this.txtYear.DataBindings.Add("Visible", this._bindingList[0], "IsRead", true, DataSourceUpdateMode.OnPropertyChanged);
            this.txtYear.DataBindings.Add("Text", this._bindingList[0], "CurrentBook.PublishYear", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void CurrentBookOnChanged(object sender, EventArgs e)
        {
            if (sender is not ListBox lb) return;

            if (lb.SelectedValue is IBook book)
            {
                if (this.ViewModel.CurrentBook != null && this.ViewModel.CurrentBook == book) return;
                this.ViewModel.CurrentBook = book;
            }
            else
            {
                var isbn = lb.SelectedValue as string;
                this.ViewModel.CurrentBook = this.ViewModel.Books.SingleOrDefault(b => b.Isbn.Equals(isbn));
            }

            this.UpdateBindings();
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