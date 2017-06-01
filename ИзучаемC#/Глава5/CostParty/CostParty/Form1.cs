using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CostParty
{
    public partial class Form1 : Form
    {
        DinnerParty dinnerParty;

        public Form1()
        {
            InitializeComponent();

            dinnerParty = new DinnerParty ((int)numericUpDown1.Value,HelthyBox.Checked,FancyBox.Checked);
            DisplayDinnerPartyCost();

       
        }
        
        private void DisplayDinnerPartyCost()
        {
            decimal Cost = dinnerParty.Cost;
            costLabel.Text = Cost.ToString("c");

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            dinnerParty.NumberOfPeople = (int)numericUpDown1.Value;
            DisplayDinnerPartyCost();
        }

        private void FancyBox_CheckedChanged(object sender, EventArgs e)
        {
            dinnerParty.FancyDecorations=(FancyBox.Checked);
            DisplayDinnerPartyCost();
        }

        private void HelthyBox_CheckedChanged(object sender, EventArgs e)
        {
            dinnerParty.HelthyOption=(HelthyBox.Checked);
            DisplayDinnerPartyCost();
        }

    }
}
