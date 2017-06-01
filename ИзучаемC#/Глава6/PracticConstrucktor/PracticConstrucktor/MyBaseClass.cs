using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace PracticConstrucktor
{
    class MyBaseClass
    {
        public MyBaseClass(string baseClassNeedThis)
        {
            MessageBox.Show("This is the base class:" + baseClassNeedThis);
        }
    }
}
