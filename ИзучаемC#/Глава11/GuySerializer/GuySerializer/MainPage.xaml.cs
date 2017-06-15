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

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace GuySerializer
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

        private void WritteJoe_Click(object sender, RoutedEventArgs e)
        {
            guyManager.WriteGuyAsync(guyManager.Joe);
        }

        private void WritteBob_Click(object sender, RoutedEventArgs e)
        {
            guyManager.WriteGuyAsync(guyManager.Bob);
        }

        private void WritteEd_Click(object sender, RoutedEventArgs e)
        {
            guyManager.WriteGuyAsync(guyManager.Ed);
        }

        private void ReadNewGuy_Click(object sender, RoutedEventArgs e)
        {
            guyManager.ReadGuyAsync();
        }
    }
}
