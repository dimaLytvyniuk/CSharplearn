using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeesWorking_2._0
{
    public partial class Form1 : Form
    {
        Worker[] workers;
        Queen queen;

       
        public Form1()
        {
            InitializeComponent();
            workerBeeJob.SelectedIndex = 0;
            Worker[] workers = new Worker[4];
            workers[0]= new Worker(new string[] {"Nectar collector","Honey manufacturing" },175);
            workers[1]= new Worker(new string[] {"Egg care","Baby bee tutoring"  },114);
            workers[2]= new Worker(new string[] {"Hive maintenance","Sting patrol" },149);
            workers[3]= new Worker(new string[] { "Nectar collector", "Honey manufacturing", "Egg care", "Baby bee tutoring", "Hive maintenance", "Sting patrol" },155);

            queen = new Queen(workers,275);
        }

        private void workerBeeJob_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void assign_Click(object sender, EventArgs e)
        {
            queen.AssignWork(workerBeeJob.SelectedItem.ToString(), (int)shifts.Value);
        }

        private void nextShift_Click(object sender, EventArgs e)
        {
            
            report.Text= queen.WorkTheNextShift();
        }
    }
}
