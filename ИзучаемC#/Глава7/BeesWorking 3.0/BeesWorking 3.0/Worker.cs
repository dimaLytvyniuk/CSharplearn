using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeesWorking_3._0
{
    class Worker :Bee
    {
        private string[] jobsICanDo;
        private int shiftsToWork , shiftsWorked; 

        public Worker(string[] jobs,double weightMg) : base(weightMg) 
        {
            jobsICanDo = jobs;
        }

        private string currentJob;

        public string CurrentJob
        {
            get
            {
                return currentJob;
            }
        }

       
        public int ShiftsLeft
        {
            get
            {
                return (shiftsToWork - shiftsWorked);
            }
        }

        public bool DoThisJob(string job,int shits)
        {
            bool can=false;
            bool empty=false;
            for(int i=0;i <jobsICanDo.Length;i++)
            {
                if (jobsICanDo[i]==job)
                {
                    empty = true;
                }
            }

            if ((empty) && (String.IsNullOrEmpty(CurrentJob)))
            {
                can = true;
                currentJob = job;
                shiftsToWork = shits;
                shiftsWorked = 0;
            }
            return can;
        }

        public bool DidYouFinish()
        {
            

            if (String.IsNullOrEmpty(CurrentJob))
                return false;

            shiftsWorked += 1;
            if (shiftsWorked > shiftsToWork)
            {
                shiftsWorked = 0;
                shiftsToWork = 0;
                currentJob = null;
                return true;
            }
            else
                return false;
            
        }

        public override double HoneyConsumptionRate()
        {
            double consumption = base.HoneyConsumptionRate();
            consumption += shiftsWorked * (0.65);
            return consumption;
        }
    }
}
