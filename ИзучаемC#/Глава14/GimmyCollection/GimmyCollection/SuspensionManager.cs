using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace GimmyCollection
{
    class SuspensionManager
    {
        public static string CurrentQuery { get; set; }

        private const string filename = "_sessionState.txt";

        public static async Task SaveAsync()
        {
            if (String.IsNullOrEmpty(CurrentQuery))
                CurrentQuery = String.Empty;
            IStorageFile storageFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(storageFile, CurrentQuery);
        }

        public static async Task RestoreAsync()
        {
            IStorageFile storageFile = await ApplicationData.Current.LocalFolder.GetFileAsync(filename);
            CurrentQuery = await FileIO.ReadTextAsync(storageFile);
        }
    }
}
