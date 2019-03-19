using System;
using Autofac;
using TestTab.Interfaces;
using TestTab.Services;
using Xamarin.Forms;

namespace TestTab.Bootstrapping.Modules
{
    public class DependencyRegistrationModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ViewFactory>().As<IViewFactory>().SingleInstance();
            builder.RegisterType<Navigator>().As<INavigator>().SingleInstance();
            builder.Register<INavigation>(context => {
                var tabbed = Application.Current.MainPage as TabbedPage;

                var page = tabbed != null
                    ? tabbed.CurrentPage.Navigation
                    : Application.Current.MainPage.Navigation;
                return page; }).SingleInstance();
        }


    }
}
