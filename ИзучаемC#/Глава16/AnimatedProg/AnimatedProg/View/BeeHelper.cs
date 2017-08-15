using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace AnimatedProg.View
{
    static class BeeHelper
    {
        public static AnimatedImage BeeFactory(double width, double height, TimeSpan flapInterval)
        {
            List<string> imageNames = new List<string>();
            imageNames.Add("batman_1.png");
            imageNames.Add("batman_2.png");
            imageNames.Add("batman_3.png");
            imageNames.Add("batman_4.png");

            AnimatedImage bee = new AnimatedImage(imageNames, flapInterval);
            bee.Width = width;
            bee.Height = height;
            return bee;
        }

        public static void SetBeeLovcation(AnimatedImage bee, double x, double y)
        {
            Canvas.SetLeft(bee, x);
            Canvas.SetTop(bee, y);
        }

        public static void MakeBeeMove(AnimatedImage bee, double fromX, double toX, double y)
        {
            Canvas.SetTop(bee, y);
            Storyboard storyboard = new Storyboard();
            DoubleAnimation animation = new DoubleAnimation();
            Storyboard.SetTarget(animation, bee);
            Storyboard.SetTargetProperty(animation, "(Canvas.Left)");
            animation.From = fromX;
            animation.To = toX;
            animation.Duration = TimeSpan.FromSeconds(3);
            animation.RepeatBehavior = RepeatBehavior.Forever;
            animation.AutoReverse = true;
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }
    }
}
