using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace GuysAndCash
{

    public partial class Form1 : Form
    {
        BinaryFormatter formatter = new BinaryFormatter();
        Guy joe;
        Guy bob ; 

        int bank = 100;
        
        
        public void UpdateForm()
        {
            JoeCash.Text = "$" + joe.Cash;
            BobCash.Text = "$" + bob.Cash;
            BankCash.Text = "$" + bank;
        }
        public Form1()
        {
         
            InitializeComponent();

            joe = new Guy() {Cash=50,Name="Joe"};
            
            bob = new Guy();

            bob.Name = "Bob";
            bob.Cash = 100;

            UpdateForm();
        }

        private void buttonGive_Click(object sender, EventArgs e)
        {
            if (bank>=10)
            {
                bank -= joe.ReceiveCash(10);
                UpdateForm();
            }
            else
            {
                MessageBox.Show("В банке нет денег.");
            }
        }

        private void buttonReceive_Click(object sender, EventArgs e)
        {
            bank += bob.GiveCash(5);
            UpdateForm();
        }

        private void GiveJoe_Click(object sender, EventArgs e)
        {
            if (joe.Cash>=10)
            {
                joe.Cash -= 10;
                bob.Cash += 10;
                UpdateForm();
            }
            else
            {
                MessageBox.Show("У Joe нет денег.");
            }
        }

        private void GiveBob_Click(object sender, EventArgs e)
        {
            if (bob.Cash >= 5)
            {
                joe.Cash += 5;
                bob.Cash -= 5;
                UpdateForm();
            }
            else
            {
                MessageBox.Show("У Boba нет денег.");
            }
        }

        private void saveJoe_Click(object sender, EventArgs e)
        {
            using (Stream output = File.Create("Guy_File.dat"))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(output, joe);
            }
        }

        private void loadJoe_Click(object sender, EventArgs e)
        {
            using (Stream input = File.OpenRead("Guy_File.dat"))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                joe = (Guy)formatter.Deserialize(input);
            }
            UpdateForm();
        }
    }
}
