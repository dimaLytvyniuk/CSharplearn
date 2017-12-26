using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageFeatures.Models
{
    public static class MyExtensionMethods
    {
        public static decimal TotalPrices(this ShoppingCart shoppingCart)
        {
            decimal total = 0;
            foreach (Product prod in shoppingCart.Products)
            {
                total += prod?.Price ?? 0;
            }
            return total;
        }
    }
}
