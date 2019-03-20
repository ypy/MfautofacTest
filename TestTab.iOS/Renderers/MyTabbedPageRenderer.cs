using System;
using System.Collections.Generic;
using TestTab.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms.PlatformConfiguration;

[assembly: ExportRenderer(typeof(TabbedPage), typeof(MyTabbedPageRenderer))]
namespace TestTab.iOS.Renderers
{
    public class MyTabbedPageRenderer : TabbedRenderer
    {

        public override void ViewWillLayoutSubviews()
        {
            base.ViewWillLayoutSubviews();

            if (TabBar != null)
            {
                foreach (var item in TabBar.Items)
                {
                    item.ImageInsets = new UIEdgeInsets(5, 0, -5, 0);
                }
            }
        }

    }
}
