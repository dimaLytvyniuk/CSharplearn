using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AboutElephant
{
    public partial class Form1 : Form
    {

        Elephant Lioyd = new Elephant() {Name="Lioyd",EarSize=40 };
        Elephant Lucinda = new Elephant() {Name="Lucinda",EarSize=32 };
        
        public Form1()
        {
            InitializeComponent();
        }

        private void AboutLucinda_Click(object sender, EventArgs e)
        {
            Lucinda.WhoAmI();
        }

        private void AboutLioyd_Click(object sender, EventArgs e)
        {
            Lioyd.WhoAmI();
        }

        private void ToSwap_Click(object sender, EventArgs e)
        {
            Elephant holder;
            holder = Lioyd;
            Lioyd = Lucinda;
            Lucinda = holder;
            MessageBox.Show("Objects swapped!");
        }

        private void haos_Click(object sender, EventArgs e)
        {
            Lioyd.TellMe("Hi!", Lucinda);

            Lioyd.SpeakTo(Lucinda, "Hello!");

            Lioyd = Lucinda;
            Lioyd.EarSize = 4321;
            Lioyd.WhoAmI();
        }
    }
}
