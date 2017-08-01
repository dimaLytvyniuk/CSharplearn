using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace SpecialEvents
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ObservableCollection<string> outputItems = new ObservableCollection<string>();

        public MainPage()
        {
            this.InitializeComponent();

            output.ItemsSource = outputItems;
        }

        private void panel_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (sender == e.OriginalSource)
                outputItems.Clear();
            outputItems.Add("The panel was pressed");
        }

        private void border_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (sender == e.OriginalSource)
                outputItems.Clear();
            outputItems.Add("The border was pressed");
            if (borderSetsHandled.IsOn)
                e.Handled = true;
        }

        private void grid_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (sender == e.OriginalSource)
                outputItems.Clear();
            outputItems.Add("The grid was pressed");
            if (gridSetsHandled.IsOn)
                e.Handled = true;
        }

        private void eclipse_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (sender == e.OriginalSource)
                outputItems.Clear();
            outputItems.Add("The elipse was pressed");
            if (eclipseSetsHandled.IsOn)
                e.Handled = true;
        }

        private void greyRectangle_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (sender == e.OriginalSource)
                outputItems.Clear();
            outputItems.Add("The greyRectangle was pressed");
            if (rectangleSetsHandled.IsOn)
                e.Handled = true;
        }

        private void updateRectangle_Click(object sender, RoutedEventArgs e)
        {
            greyRectangle.IsHitTestVisible = newHitTEstVisibleValue.IsOn;
        }
    }
}
