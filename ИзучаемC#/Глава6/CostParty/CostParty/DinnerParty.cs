using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CostParty 
{
    class DinnerParty : Party
    {
      
        public bool HelthyOption { get; set; }

        

        public DinnerParty(int numberOfPeople, bool helthyOption, bool fancyDecorations)
        {
            NumberOfPeople = numberOfPeople;
            HelthyOption = helthyOption;
            FancyDecorations = fancyDecorations;
        }

     

  

        private decimal CalculateCostOfBeveragesPerPerson()
        {
            decimal BeveragesPerPerson;
            if (HelthyOption)
            {
                BeveragesPerPerson= 5.00M;
            }
            else
            {
                BeveragesPerPerson = 20.00M;
            }
            return BeveragesPerPerson;
        }

        public override decimal Cost
        {
            get
            {

                decimal totalCost = base.Cost;
                totalCost += CalculateCostOfBeveragesPerPerson()*NumberOfPeople;
                if (HelthyOption)
                {
                    totalCost *= .95M;
                }
                return totalCost;
                
            }
        }

 

    }
}
