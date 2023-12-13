using Crm.Common;
using Crm.Common.Contracts;
using Crm.Dependencies.Contracts;
using Crm.Models.BookDomain;
using Crm.Models.Contracts.BookDomain;
using Crm.Models.Contracts.MainDomain;
using Crm.Models.MainDomain;
using Crm.Presenters;
using Crm.Presenters.Contracts;
using Crm.Repository;
using Crm.Repository.Contracts;
using Crm.Services;
using Crm.Services.Contracts;
using Crm.Views;
using Crm.Views.Contracts.Views;

namespace Crm.Bootstrapper
{
    public class DependencyInitializer
    {
        public static void Initialize(IDependencyContainer container)
        {
            RegisterCommonComponents(container);
            RegisterPresenters(container);
            RegisterRepositories(container);
            RegisterModel(container);
            RegisterForms(container);
            RegisterServices(container);
        }

        private static void RegisterCommonComponents(IDependencyContainer container)
        {
            container.RegisterType<IEventHelper, EventHelper>();
            container.RegisterTypeAsSingleton<IMessageNotificationsHelper, MessageNotificationsHelper>();
        }

        private static void RegisterPresenters(IDependencyContainer container)
        {
            container.RegisterType<IMainViewPresenter, MainViewPresenter>();
            container.RegisterType<IBooksViewPresenter, BooksViewPresenter>();
            container.RegisterType<IAddBookViewPresenter, AddBookViewPresenter>();
            container.RegisterType<IDeleteBookViewPresenter, DeleteBookViewPresenter>();
        }

        private static void RegisterRepositories(IDependencyContainer container)
        {
            container.RegisterType<IBooksRepository, BooksRepository>();
        }

        private static void RegisterModel(IDependencyContainer container)
        {
            container.RegisterType<IMainViewModel, MainViewModel>();
            container.RegisterType<IBookViewModel, BookViewModel>();
            container.RegisterType<IAddBookViewModel, AddBookViewModel>();
            container.RegisterType<IDeleteBookViewModel, DeleteBookViewModel>();

            container.RegisterType<IBook, Book>();
        }

        private static void RegisterForms(IDependencyContainer container)
        {
            container.RegisterType<IFrmMain, FrmMain>();
            container.RegisterType<IFrmBooks, FrmChildBooks>();
            container.RegisterType<IFrmAddBook, FrmChildAddBook>();
            container.RegisterType<IFrmDeleteBook, FrmChildDeleteBook>();
        }

        private static void RegisterServices(IDependencyContainer container)
        {
            container.RegisterType(typeof(IBooksService<>), typeof(BooksService<>));
        }
    }
}
