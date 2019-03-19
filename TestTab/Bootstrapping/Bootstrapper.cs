using System;
using Autofac;
using TestTab.Bootstrapping.Modules;
using TestTab.Interfaces;
using TestTab.ViewModels;
using TestTab.Views;
using Xamarin.Forms;

namespace TestTab.Bootstrapping
{
    public class Bootstrapper
    {
        private readonly App _app;

        public Bootstrapper(App app)
        {
            _app = app;
        }

        public void Run()
        {
            var builder = new ContainerBuilder();
            ConfigureContainer(builder);

            var container = builder.Build();

            var viewFactory = container.Resolve<IViewFactory>();
            RegisterViews(viewFactory);

            ConfigureApplication(container);
        }

        private void ConfigureApplication(IContainer container)
        {
            var viewFactory = container.Resolve<IViewFactory>();

            var mainPage = viewFactory.Resolve<MainViewModel>();
            //var navPage = new NavigationPage(mainPage);
            var navHome = new NavigationPage(viewFactory.Resolve<ItemsViewModel>());

            navHome.Icon = "home.png";
            navHome.Title = "Home";
            navHome.BarBackgroundColor = Color.White;
            ((TabbedPage)mainPage).Children.Add(navHome);

            var navAbout = new NavigationPage(viewFactory.Resolve<AboutViewModel>());
            navAbout.Icon = "list.png";
            navAbout.Title = "About";
            navAbout.BarBackgroundColor = Color.White;
            ((TabbedPage)mainPage).Children.Add(navAbout);

            _app.MainPage = mainPage;
        }

        private void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<DependencyRegistrationModule>();
            builder.RegisterModule<ViewModelViewRegistrationModule>();
        }

        private void RegisterViews(IViewFactory viewFactory)
        {
            viewFactory.Register<ItemsViewModel, ItemsPage>();
            viewFactory.Register<AboutViewModel, AboutPage>();
            viewFactory.Register<ItemDetailViewModel, ItemDetailPage>();
            viewFactory.Register<NewItemsViewModel, NewItemPage>();
            viewFactory.Register<MainViewModel, MainPage>();
        }
    }
}
