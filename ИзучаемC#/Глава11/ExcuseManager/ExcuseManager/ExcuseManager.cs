using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.Storage.FileProperties;
using Windows.Storage.Pickers;
using Windows.UI.Popups;

namespace ExcuseManager
{
    class ExcuseManager : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Excuse CurrentExcuse { get; set; }
        public string FileDate { get; private set; }
        private Random random = new Random();
        private IStorageFolder excuseFolder = null;
        private IStorageFile excuseFile;

        public ExcuseManager()
        {
            NewExcuseAsync();
        }

        public async void NewExcuseAsync()
        {
            CurrentExcuse = new Excuse();
            excuseFile = null;
            OnPropertyChanged("CurrentExcuse");
            await UpdateFileDateAsync();
        }

        public void SetToCurrentTime()
        {
            CurrentExcuse.LastUsed = DateTimeOffset.Now.ToString();
            OnPropertyChanged("CurrentExcuse");
        }

        public async Task<bool> ChooseNewFolderAsync()
        {
            FolderPicker folderPicker = new FolderPicker() { SuggestedStartLocation = PickerLocationId.MusicLibrary };
            folderPicker.FileTypeFilter.Add(".xml");
            IStorageFolder folder = await folderPicker.PickSingleFolderAsync();
            if (folder != null)
            {
                excuseFolder = folder;
                return true;
            }
            MessageDialog warningDialog = new MessageDialog("Folder isn't chosen");
            await warningDialog.ShowAsync();
            return false;
        }

        public async void OpenExcuseAsync()
        {
            FileOpenPicker picker = new FileOpenPicker
            {
                SuggestedStartLocation = PickerLocationId.MusicLibrary,
                CommitButtonText = "Open Excuse File"
            };
            picker.FileTypeFilter.Add(".xml");
            excuseFile = await picker.PickSingleFileAsync();
            if (excuseFile != null)
                await ReadExcuseAsync();
        }

        public async void OpenRandomExcuseAsync()
        {
            IReadOnlyList<IStorageFile> files = await excuseFolder.GetFilesAsync();
            excuseFile = files[random.Next(files.Count)];
            await ReadExcuseAsync();
        }

        private async Task UpdateFileDateAsync()
        {
            if (excuseFile != null)
            {
                BasicProperties basicProperties = await excuseFile.GetBasicPropertiesAsync();
                FileDate = basicProperties.DateModified.ToString();
            }
            else
                FileDate = "(file isn't loaded)";
            OnPropertyChanged("FileDate");
        }

        public async void SaveCurrentExcuseAsync()
        {
            if (CurrentExcuse == null)
            {
                await new MessageDialog("Excuses aren't load").ShowAsync();
                return;
            }
            if (String.IsNullOrEmpty(CurrentExcuse.Description))
            {
                await new MessageDialog("Current excuse don't have description").ShowAsync();
                return;
            }
            if (excuseFile == null)
                excuseFile = await excuseFolder.CreateFileAsync(CurrentExcuse.Description + ".xml", CreationCollisionOption.ReplaceExisting);

            await WriteExcuseAsync();
        }

        public async Task ReadExcuseAsync()
        {

        }

        public async Task WriteExcuseAsync()
        {

        }

        public async void SaveCurrentExcuseAsAsync()
        {

        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChangedEvent = PropertyChanged;
            if (propertyChangedEvent != null)
            {
                propertyChangedEvent(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
