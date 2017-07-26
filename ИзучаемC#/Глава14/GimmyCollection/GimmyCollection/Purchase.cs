using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GimmyCollection
{
        enum PriceRange { Cheap, Midrange, Expensive }

        class Purchase
        {
            public int Issuse { get; set; }
            public decimal Price { get; set; }

            public static PriceRange EvaluatePrice(decimal price)
            {
                if (price < 100M)
                    return PriceRange.Cheap;
                else if (price < 1000M)
                    return PriceRange.Midrange;
                else
                    return PriceRange.Expensive;
            }
    }
}
