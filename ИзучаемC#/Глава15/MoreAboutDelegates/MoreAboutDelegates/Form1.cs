using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoreAboutDelegates
{
    public partial class Form1 : Form
    {
        GetSecretIngredient ingredientMethod = null;
        Suzanne suzanne = new Suzanne();
        Amy amy = new Amy();

        public Form1()
        {
            InitializeComponent();
        }

        private void button_getIngredient_Click(object sender, EventArgs e)
        {
            if (ingredientMethod != null)
                MessageBox.Show("I'll add " + ingredientMethod((int)numericUpDown1.Value));
            else
                MessageBox.Show("I don't have a secret ingredient");
        }

        private void button_getSuzzane_Click(object sender, EventArgs e)
        {
            ingredientMethod = suzanne.MySecretIngredientMethod;
        }

        private void button_getAmy_Click(object sender, EventArgs e)
        {
            ingredientMethod = amy.AmysSecretIngredientMethod;
        }
    }
}
