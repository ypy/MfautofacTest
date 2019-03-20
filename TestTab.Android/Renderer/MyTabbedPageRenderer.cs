using System;
using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Android.Support.Design.Internal;
using Android.Views;
using Android.Widget;
using TestTab.Droid.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(TabbedPage), typeof(MyTabbedPageRenderer))]
namespace TestTab.Droid.Renderer
{
    public class MyTabbedPageRenderer : TabbedPageRenderer
    {
        public MyTabbedPageRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<TabbedPage> e)
        {
            base.OnElementChanged(e);

            var childViews = GetAllChildViews(ViewGroup);

            var scale = Resources.DisplayMetrics.Density;
            var paddingDp = 9;
            var dpAsPixels = (int)(paddingDp * scale + 0.5f);

            foreach (var childView in childViews)
            {
                if (childView is BottomNavigationItemView tab)
                {
                    tab.SetPadding(tab.PaddingLeft, dpAsPixels, tab.PaddingRight, tab.PaddingBottom);
                }
                else if (childView is TextView textView)
                {
                    textView.SetTextColor(Android.Graphics.Color.Transparent);
                }
            }
        }

        List<Android.Views.View> GetAllChildViews(Android.Views.View view)
        {
            if (!(view is ViewGroup group))
            {
                return new List<Android.Views.View> { view };
            }

            var result = new List<Android.Views.View>();

            for (int i = 0; i < group.ChildCount; i++)
            {
                var child = group.GetChildAt(i);

                var childList = new List<Android.Views.View> { child };
                childList.AddRange(GetAllChildViews(child));

                result.AddRange(childList);
            }

            return result.Distinct().ToList();
        }
    }
}
