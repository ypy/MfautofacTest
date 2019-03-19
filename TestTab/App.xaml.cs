﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TestTab.Views;
using TestTab.Bootstrapping;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TestTab
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            LoadTypes();
        }

        private void LoadTypes()
        {
            var bootstrapper = new Bootstrapper(this);
            bootstrapper.Run();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
