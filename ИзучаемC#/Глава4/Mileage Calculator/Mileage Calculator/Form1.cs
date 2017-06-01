using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mileage_Calculator
{
    public partial class Form1 : Form
    {
        int startingMileage, endingMileage;
        double milesTraveled,  amountOwed;
        double reiburseRate=39;

        public Form1()
        {
            InitializeComponent();
        }

        private void ToCalculate_Click(object sender, EventArgs e)
        {
            if (StartMileage.Value<EndMileage.Value)
            {
                endingMileage=(int)EndMileage.Value;
                startingMileage=(int)StartMileage.Value;

                milesTraveled = endingMileage -= startingMileage;
                amountOwed = milesTraveled *= reiburseRate;
                MoneyToOwn.Text = "$" + amountOwed;

            }
            else
            {
                MessageBox.Show("You're duren","Cannot Calculate Mileage");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
            MessageBox.Show(milesTraveled+"miles", "Miles Traveled");
        }
    }
}
