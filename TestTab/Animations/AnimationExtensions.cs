﻿using System;
using System.Threading.Tasks;
using Xamarin.Forms;
//using Xamarin.Forms;

namespace TestTab.Animations
{
    public static class AnimationExtensions
    {
        public static Task<bool> ChangeBackgroundColorTo(this Button self, Color newColor, uint length = 250, Easing easing = null)
        {
            Task<bool> ret = new Task<bool>(() => false);

            if (!self.AnimationIsRunning(nameof(ChangeBackgroundColorTo)))
            {
                Color fromColor = self.BackgroundColor;

                try
                {
                    Func<double, Color> transform = (t) =>
                      Color.FromRgba((int)(fromColor.R + t * (newColor.R - fromColor.R)),
                                    (int)(fromColor.G + t * (newColor.G - fromColor.G)),
                                    (int)(fromColor.B + t * (newColor.B - fromColor.B)),
                                    (int)(fromColor.A + t * (newColor.A - fromColor.A)));

                    ret = TransmuteColorAnimation(self, nameof(ChangeBackgroundColorTo), transform, length, easing);
                }
                catch (Exception )
                {
                    // to supress animation overlapping errors 
                    self.BackgroundColor = fromColor;
                }
            }

            return ret;
        }

        private static Task<bool> TransmuteColorAnimation(Button button, string name, Func<double, Color> transform, uint length, Easing easing)
        {
            easing = easing ?? Easing.Linear;
            var taskCompletionSource = new TaskCompletionSource<bool>();

            button.Animate(name, transform, (color) => { button.BackgroundColor = color; }, 16, length, easing, (v, c) => taskCompletionSource.SetResult(c));
            return taskCompletionSource.Task;
        }
    }
}
