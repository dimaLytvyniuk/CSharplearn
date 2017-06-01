using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayingCards
{
    public partial class Form1 : Form
    {
        Random random;
        Cards cards;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            random = new Random();
            int numberBetween0And3 = random.Next(4);
            int numberBetween1And13=random.Next(1,14);
            Suits suit = (Suits)numberBetween0And3;
            Values value = (Values)numberBetween1And13;
            cards = new Cards(suit,value);
            MessageBox.Show(cards.Name);
        }
    }
}
