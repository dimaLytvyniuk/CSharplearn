using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseballDictionary
{
    public partial class Form1 : Form
    {
        Dictionary<int, JerseyNumber> retiredNumbers = new Dictionary<int, JerseyNumber>()
        {
            {3 ,new JerseyNumber("Babe Ruth",1948) },
             {4 ,new JerseyNumber("Babe Ruth",1948) },
             { 5,new JerseyNumber("Babe Ruth",1948) },
             { 7,new JerseyNumber("Babe Ruth",1948) },
             { 8,new JerseyNumber("Babe Ruth",1948) },
             { 10,new JerseyNumber("Babe Ruth",1948) },
            { 23,new JerseyNumber("Babe Ruth",1948) },
            { 42,new JerseyNumber("Babe Ruth",1948) },
            { 44,new JerseyNumber("Babe Ruth",1948) },

        };
        public Form1()
        {
            InitializeComponent();

            foreach(int key in retiredNumbers.Keys)
            {
                number.Items.Add(key);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            JerseyNumber jerseyNumber = retiredNumbers[(int)number.SelectedItem] as JerseyNumber;
            labelName.Text = jerseyNumber.Player.ToString();
            labelYear.Text = jerseyNumber.YearRetired.ToString();
        }
    }
}
