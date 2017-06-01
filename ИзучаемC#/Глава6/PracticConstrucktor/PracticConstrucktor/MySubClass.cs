using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticConstrucktor
{
    class MySubClass : MyBaseClass
    {
        public MySubClass(string baseClassNeedThis,int anotherValue):base (baseClassNeedThis)
        {
            MessageBox.Show("This is the subclass: " + baseClassNeedThis + " and " + anotherValue);
        }
    }
}
