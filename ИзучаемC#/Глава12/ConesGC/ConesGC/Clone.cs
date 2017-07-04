using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConesGC
{
    [Serializable]
    class Clone : IDisposable
    {
        public int Id { get; private set; }

        public Clone(int Id)
        {
            this.Id = Id;
        }

        public void Dispose()
        {
            string filename = @"F:\Temp\Clone.dat";
            string dirname = @"F:\Temp\";
            if (!File.Exists(filename))
                Directory.CreateDirectory(dirname);
            BinaryFormatter bf = new BinaryFormatter();
            using (Stream output = File.OpenWrite(filename))
            {
                bf.Serialize(output, this);
            }
            MessageBox.Show("must to serialize object!", "Clone #" + Id + " speak...");
        }

        ~Clone()
        {
            MessageBox.Show("Aaaragh! You got me!", "Clone #" + Id + " says...");
        }
    }
}
