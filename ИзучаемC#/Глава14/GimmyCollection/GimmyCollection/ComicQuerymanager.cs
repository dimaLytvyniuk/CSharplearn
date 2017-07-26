using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Media.Imaging;

namespace GimmyCollection
{
    class ComicQueryManager
    {
        public ObservableCollection<ComicQuery> AvaliableQueries { get; private set; }
        public ObservableCollection<object> CurrentQueryResults { get; private set; }
        public string Title { get; set; }

        public ComicQueryManager()
        {
            UpdateAvaliableQueries();
            CurrentQueryResults = new ObservableCollection<object>();
        }

        private void UpdateAvaliableQueries()
        {
            AvaliableQueries = new ObservableCollection<ComicQuery>
            {
                new ComicQuery("LINQ makes live easier","Example of query",
                               "Present flexability of LING to Gimmy",
                               CreateImageFromAssets("StoreLogo.png")),
                new ComicQuery("Expensive comics","Comics expensiver than $500",
                               "Comics with price more than $500",
                               CreateImageFromAssets("SplashScreen.scale-200.png")),
                new ComicQuery("Universal LINQ 1","Let's change all queries",
                               "This code is adding a new string at the end of all lines in massives",
                               CreateImageFromAssets("LockScreenLogo.scale-200.png")),
                new ComicQuery("Universal LINQ 2","Calculating in collections",
                               "LINQ will give a extension methodes for Collections",
                               CreateImageFromAssets("Wide310x150Logo.scale-200.png")),
                new ComicQuery("Universal LINQ 3","Save all results in new order",
                               "Sometimes results of LINQ need to save separately",
                               CreateImageFromAssets("Square44x44Logo.scale-200.png")),
                new ComicQuery("Group comics by price range","Combine Jimmy's values into groups",
                               "Jimmy buy a lot of cheap comics, he wants to know what his options are before he decides to buy comics",
                               CreateImageFromAssets("PVuS4tr.png")),
                new ComicQuery("Join purchases with prices", "Let's see if Jimmy drives a hard bargain",
                               "This query creates a list of Purchase classes that contain Jimmy's purchases and compares them with the prices he found on Greg's list",
                               CreateImageFromAssets("watchmen.jpg")),
                new ComicQuery("All comics in Collection", "Get all comics",
                               "This query return all comics",
                               CreateImageFromAssets("vendetta.png"))
            };
        }

        private static BitmapImage CreateImageFromAssets(string fileName)
        {
            return new BitmapImage(new Uri("ms-appx:///Assets/" + fileName));
        }

        public void UpdateQueryResults(ComicQuery query)
        {
            Title = query.Tittle;

            switch (Title)
            {
                case "LINQ makes live easier": LinqMakesQueriesEasy(); break;
                case "Expensive comics": ExpensiveComics(); break;
                case "Universal LINQ 1": LinqIsVersatile1(); break;
                case "Universal LINQ 2": LinqIsVersatile2(); break;
                case "Universal LINQ 3": LinqIsVersatile3(); break;
                case "Join purchases with prices": ComparePrices(); break;
                case "Group comics by price range": GroupByRange(); break;
                case "All comics in Collection": AllComics(); break;
            }
        }

        public static IEnumerable<Comic> BuildCatalog()
        {
            return new List<Comic>
            {
                new Comic { Name = "Watchmen", Issue = 6, ImageName = "watchmen_title.png", Year = 1988, CoverPrice = "10 cents", MainVillain = "Ozimandriy", Synopsis = "Watchers", Cover = CreateImageFromAssets("watchmen_title.png")},
                new Comic { Name = "V for Vendetta", Issue = 19, ImageName = "V-for-Vendetta.jpg", Year = 1990, CoverPrice ="20 cents", MainVillain = "Goverment", Synopsis = "Guy Fox", Cover = CreateImageFromAssets("V-for-Vendetta.jpg")},
                new Comic { Name = "The Dark Knight: Return", Issue = 36, ImageName = "dark_knight.jpeg", Year = 1982, CoverPrice = "12 cents", MainVillain = "Superman", Synopsis = "Dark Knight", Cover = CreateImageFromAssets("dark_knight.jpeg")},
                new Comic { Name = "Batman: Year One", Issue = 57, ImageName = "Batman405.jpg", Year = 1984, CoverPrice = "11 cents", MainVillain = "Mafia", Synopsis = "Young Batman", Cover = CreateImageFromAssets("Batman405.jpg")},
                new Comic { Name = "Avangers: Age of Altron", Issue = 68, ImageName = "altron.jpg", Year = 1990, CoverPrice = "30 cents", MainVillain = "Altron", Synopsis = "Avangers", Cover = CreateImageFromAssets("altron.jpg")},
                new Comic { Name = "Daredevil", Issue = 74, ImageName = "daredevil.jpg", Year = 1992, CoverPrice = "15 cents", MainVillain = "The hand", Synopsis = "Daredevil", Cover = CreateImageFromAssets("daredevil.jpg")},
                new Comic { Name = "Amazing Spiderman", Issue = 83, ImageName = "spidy.jpg", Year = 2017, CoverPrice = "15 cents", MainVillain = "Vulture", Synopsis = "SpiderMan", Cover = CreateImageFromAssets("spidy.jpg")},
                new Comic { Name = "Old Man Logan", Issue = 97, ImageName = "wolverine.jpg", Year = 2015, CoverPrice = "30 cents", MainVillain = "Red skull and hulk's children", Synopsis = "Wolverine", Cover = CreateImageFromAssets("wolverine.jpg")}
            };
        }

        private static Dictionary<int, decimal> GetPrices()
        {
            return new Dictionary<int, decimal>
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

        private void LinqMakesQueriesEasy()
        {
            int[] values = new int[] { 0, 12, 44, 36, 92, 54, 13, 8 };
            int y = values.Min();
            var result = from v in values
                         where v < 37
                         orderby v
                         select v;
            CurrentQueryResults.Clear();
            foreach (int i in result)
                CurrentQueryResults.Add(
                        new
                        {
                            Title = i.ToString(),
                            Image = CreateImageFromAssets("StoreLogo.png")
                        }
                    );
        }

        private void ExpensiveComics()
        {
            IEnumerable<Comic> comics = BuildCatalog();
            Dictionary<int, decimal> values = GetPrices();

            var mostExpensive = from comic in comics
                                where values[comic.Issue] > 500
                                orderby values[comic.Issue] descending
                                select comic;

            CurrentQueryResults.Clear();
            foreach (Comic comic in mostExpensive)
                CurrentQueryResults.Add(
                        new
                        {
                            Title = String.Format("{0} is worth {1:c}", comic.Name, values[comic.Issue]),
                            Image = CreateImageFromAssets("StoreLogo.png")
                        }
                    );
        }

        public object CreateAnonymousListViewitem(string title, string imageName = "StoreLogo.png")
        {
            return new
            {
                Title = title,
                Image = CreateImageFromAssets(imageName)
            };
        }

        private void LinqIsVersatile1()
        {
            string[] sandwiches = {"ham and cheese", "salami with mayo",
                                   "turkey and swiss", "chicken cutlet"};
            var sandwichesOnRye = from sandwich in sandwiches
                                  select sandwich + " on rye";

            CurrentQueryResults.Clear();
            foreach (var sandwich in sandwichesOnRye)
                CurrentQueryResults.Add(CreateAnonymousListViewitem(sandwich, "SplashScreen.scale-200.png"));
        }

        private void LinqIsVersatile2()
        {
            Random random = new Random();
            List<int> listOfNumbers = new List<int>();
            int length = random.Next(50, 150);
            for (int i = 0; i < length; i++)
                listOfNumbers.Add(random.Next(100));

            CurrentQueryResults.Clear();
            CurrentQueryResults.Add(CreateAnonymousListViewitem(String.Format("There are {0} numbers", listOfNumbers.Count)));
            CurrentQueryResults.Add(CreateAnonymousListViewitem(String.Format("The smallest is {0}", listOfNumbers.Min())));
            CurrentQueryResults.Add(CreateAnonymousListViewitem(String.Format("The biggest is {0}", listOfNumbers.Max())));
            CurrentQueryResults.Add(CreateAnonymousListViewitem(String.Format("The Average is {0:F2}", listOfNumbers.Average())));
        }

        private void LinqIsVersatile3()
        {
            List<int> listOfNumbers = new List<int>();
            for (int i = 0; i <= 10000; i++)
                listOfNumbers.Add(i);

            var under50sorted = from number in listOfNumbers
                                where number < listOfNumbers.Average()
                                orderby number descending
                                select number;

            var firstFive = under50sorted.Take(10000);

            List<int> shortList = under50sorted.Take(6).ToList();
            foreach (int n in shortList)
                CurrentQueryResults.Add(CreateAnonymousListViewitem(n.ToString()));
        }

        private void GroupByRange()
        {
            Dictionary<int, decimal> values = GetPrices();

            var priceGroups = from pair in values
                              group pair.Key by Purchase.EvaluatePrice(pair.Value)
                              into priceGroup
                              orderby priceGroup.Key descending
                              select priceGroup;

            CurrentQueryResults.Clear();

            foreach (var group in priceGroups)
            {
                string str = String.Format("Found {0} {1} comics: editions ", group.Count(), group.Key);
                foreach (var issueNumber in group)
                    str += issueNumber + " ";
                CurrentQueryResults.Add(CreateAnonymousListViewitem(str, "watchmen.jpg"));
            }
        }

        private void ComparePrices()
        {
            IEnumerable<Comic> comics = BuildCatalog();
            IEnumerable<Purchase> purchases = FindPurchases();
            Dictionary<int, decimal> values = GetPrices();

            var results = from comic in comics
                          join purchase in purchases
                          on comic.Issue equals purchase.Issuse
                          orderby comic.Issue
                          select new { comic.Name, comic.Issue, purchase.Price };

            decimal gregsListValue = 0;
            decimal totalSpent = 0;

            CurrentQueryResults.Clear();

            foreach (var result in results)
            {
                gregsListValue += values[result.Issue];
                totalSpent += result.Price;
                CurrentQueryResults.Add(CreateAnonymousListViewitem(String.Format("Edition #{0} ({1}) bought by {2:c}\n", result.Issue, result.Name, result.Price), "PVuS4tr.png"));
            }

            CurrentQueryResults.Add(CreateAnonymousListViewitem(String.Format("i spent {0:c} for comics which cost {1:c}", totalSpent, gregsListValue), "watchmen.jpg"));
        }
        private void AllComics()
        {
            CurrentQueryResults.Clear();

            foreach (Comic comic in BuildCatalog())
            {
                var result = new
                {
                    Image = CreateImageFromAssets(comic.ImageName),
                    Title = comic.Name,
                    Subtitle = "Issue #" + comic.Issue,
                    Description = comic.Synopsis + " versus " + comic.MainVillain,
                    Comic = comic,
                };
                CurrentQueryResults.Add(result);
            }
        }
    }
}
