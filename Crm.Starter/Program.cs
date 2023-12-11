// See https://aka.ms/new-console-template for more information

using Crm.Bootstrapper;
using Crm.Dependencies.Builder;
using Crm.Presenters.Contracts;

Console.WriteLine("Hello, MVVM!");

DependencyInitializer.Initialize(DependencyContainerFactory.Init());

Application.EnableVisualStyles();
Application.SetCompatibleTextRenderingDefault(false);

Application.Run((Form)DependencyContainerFactory.Container.Resolve<IMainViewPresenter>().GetView());