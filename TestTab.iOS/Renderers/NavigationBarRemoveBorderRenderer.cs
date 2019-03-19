using System;
using TestTab.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(NavigationPage), typeof(NavigationBarRemoveBorderRenderer))]
namespace TestTab.iOS.Renderers
{
    public class NavigationBarRemoveBorderRenderer : NavigationRenderer
    {
        public NavigationBarRemoveBorderRenderer()
        {
            UINavigationBar.Appearance.SetBackgroundImage(new UIImage(), UIBarMetrics.Default);
            UINavigationBar.Appearance.ShadowImage = new UIImage();
        }

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            NavigationBar.SetBackgroundImage(new UIKit.UIImage(), UIKit.UIBarMetrics.Default);
            NavigationBar.ShadowImage = new UIKit.UIImage();
        }
    }
}
