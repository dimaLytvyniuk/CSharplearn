using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeesWorking
{
    class Worker
    {
        private string[] jobsICanDo;
        private int shiftsToWork , shiftsWorked; 

        public Worker(string[] jobs)
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
    }
}
