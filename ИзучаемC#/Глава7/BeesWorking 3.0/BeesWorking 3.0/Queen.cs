using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeesWorking_3._0
{
    class Queen : Bee
    {
        private Worker[] workers;

        public Queen(Worker[] worker,double weightMg): base (weightMg)
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
            double Honey=0;
            id+= ("Report for shift#" + shiftNumber + "\r\n\'");

            int j = 0;

            for (int i=0;i<workers.Length;i++)
            {
                j += 1;
                Honey += workers[i].HoneyConsumptionRate();
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

            Honey += HoneyConsumptionRate();
            id += ("Total honey consumed for the shift: " + Honey + " units\r\n");
            return id;
        }

    }
}
