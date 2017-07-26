using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace GimmyCollection
{
    class Comic
    {
        public string Name { get; set; }
        public int Issue { get; set; }
        public string ImageName { get; set; }
        public int Year { get; set; }
        public string CoverPrice { get; set; }
        public string Synopsis { get; set; }
        public string MainVillain { get; set; }
        public BitmapImage Cover { get; set; }
    }
}
