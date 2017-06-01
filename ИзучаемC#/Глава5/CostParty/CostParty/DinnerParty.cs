using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CostParty
{
    class DinnerParty
    {
        public int NumberOfPeople { get; set; }
        public bool FancyDecorations { get; set; }
        public bool HelthyOption { get; set; }

        public const decimal CostOfFoodPerPerson = 25.00M;

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

        public decimal Cost
        {
            get
            {
                
                decimal totalCost = CalculateCostOfDecorations();
                totalCost += ((CalculateCostOfBeveragesPerPerson()+CostOfFoodPerPerson)*NumberOfPeople);
                if (HelthyOption)
                {
                    totalCost *= .95M;
                }
                return totalCost;
                
            }
        }

        private decimal CalculateCostOfDecorations()
        {
            decimal CostOfDecorations;
            if (FancyDecorations)
            {
                CostOfDecorations=(NumberOfPeople*15.00M)+50M;
            }
            else
            {
                CostOfDecorations= (NumberOfPeople * 7.50M) + 30M;
            }
            return CostOfDecorations;
        }

    }
}
