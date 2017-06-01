using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Шаблон элемента пустой страницы задокументирован по адресу http://go.microsoft.com/fwlink/?LinkId=234238

namespace PractiseUsingIfElse
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void changeText_Click(object sender, RoutedEventArgs e)
        {

            if (enableCheckbox.IsChecked==true)
            {
                if (labelToChange.Text == "Left")
                {
                    labelToChange.Text = "Right";
                    labelToChange.HorizontalAlignment = HorizontalAlignment.Right;
                }
                else
                {
                    labelToChange.Text = "Left";
                    labelToChange.HorizontalAlignment = HorizontalAlignment.Left;
                }
            }
            else
            {
                labelToChange.Text = "Text changing is disabled";
                labelToChange.HorizontalAlignment = HorizontalAlignment.Center;
            }
        }

        private void Result_Click(object sender, RoutedEventArgs e)
        {
            int x = 0;
            string poem = "";
            while(x<4)
            {
                
                poem = poem + "a";
            if (x<1)
            {
                poem = poem + " ";
            }
            poem = poem + "n";
             if (x>1)
             {
                 poem = poem + " oyster ";
                 x = x + 2;
             }
                if (x==1)
                {
                    poem = poem + "noys ";
                }
                if (x<1)
                {
                    poem = poem + "oise ";
                }
                
                
                x = x + 2;

            }
            ResultLabel.Text = poem;
        }
    }
}
