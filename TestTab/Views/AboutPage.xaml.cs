using System;
using System.Linq;
using TestTab.Animations;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestTab.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            //#region You will not need this block, it is just to choose a random color for change to
            //var colors = new[] { Color.Red, Color.Pink, Color.Silver, Color.Yellow, Color.Black, Color.Green };
            //var rnd = new Random();

            //var actualColor = testEffect.BackgroundColor;
            //var randomColor = colors.Where(c => c != actualColor).ToArray()[rnd.Next(0, colors.Length - 2)];
            //#endregion

            //// Here is the effective use of the smooth background color change animation
            //await testEffect.ChangeBackgroundColorTo(randomColor, 150, Easing.CubicOut);
            //await testEffect.ChangeBackgroundColorTo(actualColor, 100, Easing.SinOut);
        }
    }
}