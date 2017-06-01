using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cows
{
    class Farmer
    {
        public int BagsOfFeed { get;private set; }

        private int feedMultipier;
        public int FeedMultipier { get { return feedMultipier; } }

        private int numberOfCows;
        public int NumberOfCows
        {
            get
            {
                return numberOfCows;
            }
            set
            {
                numberOfCows = value;
                BagsOfFeed = numberOfCows * FeedMultipier;
            }
        }
    }
}
