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
            if (files.Count > 0)
            {
                excuseFile = files[random.Next(files.Count)];
                await ReadExcuseAsync();
            }
            else
                await new MessageDialog("No files in folder").ShowAsync();
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
            if (excuseFile != null)
            {
                using (IRandomAccessStream stream = await excuseFile.OpenAsync(FileAccessMode.Read))
                using (Stream inputStream = stream.AsStreamForRead())
                {
                    DataContractSerializer serializer = new DataContractSerializer(typeof(Excuse));
                    try
                    {
                        CurrentExcuse = serializer.ReadObject(inputStream) as Excuse;
                    }
                    catch
                    {
                        new MessageDialog("IncorrectFile " + excuseFile.Name).ShowAsync();
                        NewExcuseAsync();
                        return;
                    }
                    finally
                    {
                        OnPropertyChanged("CurrentExcuse");
                    }
                }
                await new MessageDialog("Changing in file" + excuseFile.Name).ShowAsync();
                await UpdateFileDateAsync();
            }
        }

        public async Task WriteExcuseAsync()
        {
            if (CurrentExcuse != null)
            {
                using (IRandomAccessStream stream = await excuseFile.OpenAsync(FileAccessMode.ReadWrite))
                using (Stream outputStream = stream.AsStreamForWrite())
                {
                    DataContractSerializer serializer = new DataContractSerializer(typeof(Excuse));
                    serializer.WriteObject(outputStream, CurrentExcuse);
                }
                await new MessageDialog("Changing in file" + excuseFile.Name).ShowAsync();
                OnPropertyChanged("CurrentExcuse");
                await UpdateFileDateAsync();
            }
        }

        public async void SaveCurrentExcuseAsAsync()
        {

            FileSavePicker picker = new FileSavePicker
            {
                DefaultFileExtension = ".xml",
                SuggestedStartLocation = PickerLocationId.MusicLibrary,
                SuggestedFileName = CurrentExcuse.Description
            };

            picker.FileTypeChoices.Add("Text File", new List<String>() { ".txt" });
            picker.FileTypeChoices.Add("XML File", new List<String>() { ".xml", ".xaml" });
            excuseFile = await picker.PickSaveFileAsync();
            if (excuseFile == null)
            { 
                await new MessageDialog("Incorrect file name").ShowAsync();
                return;
            }
        
            await WriteExcuseAsync();

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
