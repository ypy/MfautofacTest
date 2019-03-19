using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace TestTab.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));

            TestListViewCommand = new Command<string>(gotoListView);
        }

        void gotoListView(string str) {
            Title = str+"Test About";
        }

        public ICommand OpenWebCommand { get; }

        public ICommand TestListViewCommand { get; private set; }
    }
}