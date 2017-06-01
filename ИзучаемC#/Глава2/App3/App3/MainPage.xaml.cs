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

namespace App3
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

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string name = "Quentin";
            int x = 3;
            x = x * 17;
            double d = Math.PI / 2;
            myLabel.Text = "name is" + name + "\nx is" + x + "\nd is" + d;

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            int someValue = 3;
            string name = "Joe";
            if ((someValue==3) && (name=="Joe"))
            {
                myLabel.Text = "x is 3 and the name is Joe";
            }
            myLabel.Text = "this line runs no matter what";
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            int x = 10;
            if(x==10)
            {
                myLabel.Text = "x is 10";
            }
            else
            {
                myLabel.Text = "x isn't 10";
            }
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            int count = 0;
            while (count < 10)
            {
                count++;
            }
            for(int i=0;i<5;i++)
            {
                count--;
            }
            myLabel.Text = "The answer is " + count;
        }
    }
}
