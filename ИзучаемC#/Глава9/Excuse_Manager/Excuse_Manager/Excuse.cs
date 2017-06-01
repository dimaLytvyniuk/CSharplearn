using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Excuse_Manager
{
    [Serializable]
    class Excuse
    {
        public DateTime LastUsed{get; set;}
        public string Results { get; set; }
        public string Description { get; set; }
        public string ExcusePath { get; set; }

        public Excuse()
        {
            ExcusePath = "";
        }
         
        public Excuse(string excusePath)
        {
            OpenFile(excusePath);
        }

        public Excuse(Random random,string folder)
        {
            string[] fileNames = Directory.GetFiles(folder, "*.excuse");
            OpenFile(fileNames[random.Next(fileNames.Length)]);
        }

        private void OpenFile(string excusePath)
        {
            this.ExcusePath = excusePath;
            using (Stream input = File.OpenRead(excusePath))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                Excuse dip = (Excuse)formatter.Deserialize(input);
                Description = dip.Description;
                Results = dip.Results;
                LastUsed = dip.LastUsed;
            }
        }

        public void Save(string fileName)
        {
            using (Stream output = File.OpenWrite(fileName))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(output, this);
            }
        }
    }
}
