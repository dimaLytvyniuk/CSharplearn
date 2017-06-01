using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticConstrucktor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyBaseClass myBaseClass = new MyBaseClass("Green deep");
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySubClass mySubClass = new MySubClass("Blue deep",300);
        }
    }
}
