﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostParty
{
    class BirthdayParty : Party
    {
        
        
        private int ActualLength 
        { 
            get
            {
                if (CakeWriting.Length > MaxWritingLength())
                    return MaxWritingLength();
                else
                    return CakeWriting.Length;

                
            }
        }

        private int CakeSize()
        {
            if (NumberOfPeople <= 4)
                return 8;
            else
                return 16;
        }

        private int MaxWritingLength()
        {
            if (CakeSize() == 8)
                return 16;
            else
                return 40;
        }

        public string CakeWriting { get; set; }

        public BirthdayParty(int numberOfPeople,bool fancyDecoretions,string cakeWriting)
        {
            NumberOfPeople = numberOfPeople;
            FancyDecorations = fancyDecoretions;
            CakeWriting = cakeWriting;
        }

 

        public bool CakeWritingTooLong
        {
            get
            {
                if (CakeWriting.Length > MaxWritingLength())
                    return true;
                else
                    return false;

            }
        }

        public override decimal Cost
        {
            get
            {
                decimal totalCost = base.Cost;
               
                decimal cakeCost;
                if (CakeSize() == 8)
                    cakeCost = 4.0M + ActualLength * .25M;
                else
                    cakeCost = 75M + ActualLength * .25M;
                return totalCost + cakeCost;
            }
        }
        
    }
}
