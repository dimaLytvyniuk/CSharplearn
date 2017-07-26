using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JimmyGroup
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, decimal> values = new Dictionary<int, decimal>
            {
                { 6, 3600M },
                { 19, 500M },
                { 36, 650M },
                { 57, 1325M },
                { 68, 250M },
                { 74, 75M },
                { 83, 25.75M },
                { 97, 35.25M }
            };

            IEnumerable<Comic> comics = BuildCatalog();
            IEnumerable<Purchase> purchases = FindPurchases();

            var results = from comic in comics
                          join purchase in purchases
                          on comic.Issue equals purchase.Issuse
                          orderby comic.Issue
                          select new { comic.Name, comic.Issue, purchase.Price };

            decimal gregsListValue = 0;
            decimal totalSpent = 0;
            foreach (var result in results)
            {
                gregsListValue += values[result.Issue];
                totalSpent += result.Price;
                Console.WriteLine("Edition #{0} ({1}) bought by {2:c}", result.Issue, result.Name, result.Price);
            }

            Console.WriteLine("i spent {0:c} for comics which cost {1:c}", totalSpent, gregsListValue);

            /*
            var priceGroups = from pair in values
                              group pair.Key by EvaluatePrice(pair.Value)
                              into priceGroup
                              orderby priceGroup.Key descending
                              select priceGroup;

            foreach (var group in priceGroups)
            {
                Console.Write("Found {0} {1} comics: editions ", group.Count(), group.Key);
                foreach (var issueNumber in group)
                    Console.Write(issueNumber.ToString() + " ");
                Console.WriteLine();
            }
            */
        }

        static PriceRange EvaluatePrice(decimal price)
        {
            if (price < 100M)
                return PriceRange.Cheap;
            else if (price < 1000M)
                return PriceRange.Midrange;
            else
                return PriceRange.Expensive;
        }

        public static IEnumerable<Purchase> FindPurchases()
        {
            return new List<Purchase>()
            {
                new Purchase(){ Issuse = 68, Price = 225M },
                new Purchase(){ Issuse = 19, Price = 375M },
                new Purchase(){ Issuse = 6, Price = 3600M },
                new Purchase(){ Issuse = 57, Price = 13215M },
                new Purchase(){ Issuse = 36, Price = 660M}
            };
        }

        public static IEnumerable<Comic> BuildCatalog()
        {
            return new List<Comic>
            {
                new Comic { Name = "Watchers", Issue = 6},
                new Comic { Name = "V for Vendetta", Issue = 19},
                new Comic { Name = "The Dark Knight: Return", Issue = 36},
                new Comic { Name = "Batman: Year One", Issue = 57},
                new Comic { Name = "Avangers: Age of Altron", Issue = 68},
                new Comic { Name = "Daredevil", Issue = 74},
                new Comic { Name = "Amazing Spiderman", Issue = 83},
                new Comic { Name = "Old Man Logan", Issue = 97}
            };
        }
    }

    enum PriceRange { Cheap, Midrange, Expensive}

    class Purchase
    {
        public int Issuse { get; set; }
        public decimal Price { get; set; }
    }

    class Comic
    {
        public string Name { get; set; }
        public int Issue { get; set; }
    }

}
