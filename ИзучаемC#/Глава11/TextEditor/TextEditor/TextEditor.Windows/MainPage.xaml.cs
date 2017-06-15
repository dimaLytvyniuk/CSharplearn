using TextEditor.Common;
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
using Windows.System;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Popups;

// Документацию по шаблону элемента "Основная страница" см. по адресу http://go.microsoft.com/fwlink/?LinkId=234237

namespace TextEditor
{
    /// <summary>
    /// Основная страница, которая обеспечивает характеристики, являющимися общими для большинства приложений.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();
        bool textchanged = false;
        bool loading = false;
        IStorageFile saveFile = null;

        /// <summary>
        /// Эту настройку можно изменить на модель строго типизированных представлений.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// NavigationHelper используется на каждой странице для облегчения навигации и 
        /// управление жизненным циклом процесса
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }


        public MainPage()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;
        }

        /// <summary>
        /// Заполняет страницу содержимым, передаваемым в процессе навигации. Любое сохраненное состояние также является
        /// при повторном создании страницы из предыдущего сеанса.
        /// </summary>
        /// <param name="sender">
        /// Источник события; обычно <see cref="Common.NavigationHelper"/>
        /// </param>
        /// <param name="e">Данные события, предоставляющие параметр навигации, который передается
        /// <see cref="Frame.Navigate(Type, Object)"/> при первоначальном запросе этой страницы, и
        /// словарь состояния, сохраненного этой страницей в ходе предыдущего
        /// сеансом. Состояние будет равно значению NULL при первом посещении страницы.</param>
        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        /// <summary>
        /// Сохраняет состояние, связанное с данной страницей, в случае приостановки приложения или
        /// удаления страницы из кэша навигации.  Значения должны соответствовать требованиям сериализации
        /// требования <see cref="Common.SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">Источник события; обычно <see cref="Common.NavigationHelper"/></param>
        /// <param name="e">Данные события, которые предоставляют пустой словарь для заполнения
        /// сериализуемым состоянием.</param>
        private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region Регистрация NavigationHelper

        /// Методы, предоставленные в этом разделе, используются исключительно для того, чтобы
        /// NavigationHelper для отклика на методы навигации страницы.
        /// 
        /// Логика страницы должна быть размещена в обработчиках событий для 
        /// <see cref="Common.NavigationHelper.LoadState"/>
        /// и <see cref="Common.NavigationHelper.SaveState"/>.
        /// Параметр навигации доступен в методе LoadState 
        /// в дополнение к состоянию страницы, сохраненному в ходе предыдущего сеанса.

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private void text_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (loading)
            {
                loading = false;
                return;
            }
            if (!textchanged)
            {
                fileName.Text += "*";
                saveButton.IsEnabled = true;
                textchanged = true;   
            }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFile();
        }

        private async void openButton_Click(object sender, RoutedEventArgs e)
        {
            if (textchanged)
            {
                MessageDialog overwriteDialog = new MessageDialog("Are you sure, you want to open new file?");
                overwriteDialog.Commands.Add(new UICommand("Yes"));
                overwriteDialog.Commands.Add(new UICommand("No"));
                overwriteDialog.DefaultCommandIndex = 1;
                UICommand result = await overwriteDialog.ShowAsync() as UICommand;
                if (result != null && result.Label == "No")
                    return;

                OpenFile();
            }
        }

        private async void OpenFile()
        {
            FileOpenPicker picker = new FileOpenPicker { ViewMode = PickerViewMode.List, SuggestedStartLocation = PickerLocationId.DocumentsLibrary };
            picker.FileTypeFilter.Add(".txt");
            picker.FileTypeFilter.Add(".xml");
            picker.FileTypeFilter.Add(".xaml");
            IStorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                string fileContents = await FileIO.ReadTextAsync(file);
                loading = true;
                text.Text = fileContents;
                textchanged = false;
                fileName.Text = file.Name;
                saveFile = file;
            }
        }

        private async void SaveFile()
        {
            if (saveFile == null)
            {
                FileSavePicker picker = new FileSavePicker { DefaultFileExtension = ".txt", SuggestedStartLocation = PickerLocationId.DocumentsLibrary };
                picker.FileTypeChoices.Add("Text File", new List<string>() { ".txt" });
                picker.FileTypeChoices.Add("XML File", new List<string>() { ".xml", ".xaml" });
                saveFile = await picker.PickSaveFileAsync();
                if (saveFile == null) return;
            }
            await FileIO.WriteTextAsync(saveFile, text.Text);
            await new MessageDialog("Wrote " + saveFile.Name).ShowAsync();

            textchanged = false;
            fileName.Text = saveFile.Name;
        }
    }
}
