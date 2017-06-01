using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostParty
{
    class Party
    {
        public const decimal CostOfFoodPerPerson = 25.00M;

        public int NumberOfPeople { get; set; }
        public bool FancyDecorations { get; set; }

        private decimal CalculateCostOfDecorations()
        {
            decimal CostOfDecorations;
            if (FancyDecorations)
            {
                CostOfDecorations = (NumberOfPeople * 15.00M) + 50M;
            }
            else
            {
                CostOfDecorations = (NumberOfPeople * 7.50M) + 30M;
            }
            return CostOfDecorations;
        }

        public virtual decimal Cost
        {
            get
            {
                decimal totalCost = CalculateCostOfDecorations();
                totalCost += CostOfFoodPerPerson * NumberOfPeople;
                if (NumberOfPeople>12)
                {
                    totalCost += 100.00M;
                }
                return totalCost;
            }
        }

    }
}
