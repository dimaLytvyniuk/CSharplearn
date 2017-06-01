using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeesWorking
{
    class Queen
    {
        private Worker[] workers;

        public Queen(Worker[] worker)
        {
            workers = worker;
        }

        private int shiftNumber=0;

        public bool AssignWork(string job,int shfts)
        {
            bool can=false;
            for (int i = 0; i <4;i++)
            {
                if (workers[i].DoThisJob(job,shfts))
                {
                    can = true;
                    i = 7;
                }
            }
            return can;
        }

        public string WorkTheNextShift()
        {
            shiftNumber += 1;
            string id="";
          
            id+= ("Report for shift#" + shiftNumber + "\r\n\'");

            int j = 0;

            for (int i=0;i<workers.Length;i++)
            {
                j += 1;

                if (workers[i].DidYouFinish())
                {
                    id += ("Worker #" + j + " finished the job\r\n");

                }

                if (workers[i].CurrentJob == null)
                {
                    id+= ("Worker #" + j + " is not working\r\n");
                }
               
          
                    else
                    {
                    if (workers[i].ShiftsLeft > 0)
                        id += ("Worker #" + j + " is doing '" + workers[i].CurrentJob + "' for " + workers[i].ShiftsLeft + " more shifts\r\n");
                    else
                        id += ("Worker #" + j + " will be done with '" + workers[i].CurrentJob + "' after this shift\r\n");
                }
                
            }

            return id;
        }

    }
}
