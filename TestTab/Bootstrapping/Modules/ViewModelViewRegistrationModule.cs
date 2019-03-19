using System;
using Autofac;
using TestTab.ViewModels;
using TestTab.Views;

namespace TestTab.Bootstrapping.Modules
{
    public class ViewModelViewRegistrationModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ItemsPage>().SingleInstance();
            builder.RegisterType<ItemsViewModel>().SingleInstance();

            builder.RegisterType<AboutPage>().SingleInstance();
            builder.RegisterType<AboutViewModel>().SingleInstance();

            builder.RegisterType<ItemDetailPage>().SingleInstance();
            builder.RegisterType<ItemDetailViewModel>().SingleInstance();

            builder.RegisterType<MainPage>().SingleInstance();
            builder.RegisterType<MainViewModel>().SingleInstance();

            builder.RegisterType<NewItemPage>().SingleInstance();
            builder.RegisterType<NewItemsViewModel>().SingleInstance();
        }
    }
}
