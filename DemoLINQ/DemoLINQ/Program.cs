using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSource;

namespace DemoLINQ
{
    class Program
    {
        static void Main()
        {
            QuerySyntax();
            MethodSyntax();
            DeferredQuery();
            Sorting();

            Console.WriteLine("\n Grouping by country:");
            Grouping();

            Console.WriteLine("\n Inner Join:");
            InnerJoin();

            Console.WriteLine("\n Left Outer Join:");
            LeftOuterJoin();

            Console.ReadKey();
        }

        static void QuerySyntax()
        {
            var query = from r in Formula1.GetChampions()
                        where r.Country == "Brazil"
                        orderby r.Wins descending
                        //select r;
                        select new { r.FirstName, r.LastName, r.Wins };

            foreach (var r in query)
            {
                Console.WriteLine($"{r:A}");
            }
            Console.WriteLine();
        }

        static void MethodSyntax()
        {
            var champions = new List<Racer>(Formula1.GetChampions());
            IEnumerable<Racer> brazilChampions = champions.Where(r => r.Country == "Brazil").
                                                 OrderByDescending(r => r.Wins).
                                                 Select(r => r);

            foreach (Racer r in brazilChampions)
            {
                Console.WriteLine($"{r:A}");
            }
            Console.WriteLine();
        }

        static void DeferredQuery()
        {
            var names = new List<string> { "Nino", "Alberto", "Juan", "Mike", "Phil" };

            var namesWithJ = from n in names
                             where n.StartsWith("J")
                             orderby n
                             select n;
            
            Console.WriteLine("First iteration");
            foreach (string name in namesWithJ)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();

            names.Add("John");
            names.Add("Jim");
            names.Add("Jack");
            names.Add("Denny");

            Console.WriteLine("Second iteration");
            foreach (string name in namesWithJ)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();

        }

        private static void Sorting()
        {
            var racers = (from r in Formula1.GetChampions()
                          orderby r.Country, r.LastName, r.FirstName
                          select r).Take(10);

            foreach (var racer in racers)
            {
                Console.WriteLine($"{racer.Country}: {racer.LastName}, {racer.FirstName}");
            }

            Console.WriteLine();

            // use method syntax
            var racers2 = Formula1.GetChampions()
                        .OrderBy(r => r.Country)
                        .ThenBy(r => r.LastName)
                        .ThenBy(r => r.FirstName)
                        .Take(10);

            foreach (var racer in racers2)
            {
                Console.WriteLine($"{racer.Country}: {racer.LastName}, {racer.FirstName}");
            }
        }

        static void Grouping()
        {
            var countries = from r in Formula1.GetChampions()
                            group r by r.Country into g
                            orderby g.Count() descending, g.Key
                            where g.Count() >= 2
                            select new
                            {
                                Country = g.Key,
                                Count = g.Count()
                            };

            //var countries = from r in Formula1.GetChampions()
            //                group r by r.Country into g
            //                let count = g.Count()
            //                orderby count descending, g.Key
            //                where count >= 2
            //                select new
            //                {
            //                    Country = g.Key,
            //                    Count = count
            //                };

            foreach (var item in countries)
            {
                Console.WriteLine($"{item.Country,-10} {item.Count}");
            }
        }

        static void InnerJoin()
        {
            var racers = from r in Formula1.GetChampions()
                         from y in r.Years
                         select new
                         {
                             Year = y,
                             Name = r.FirstName + " " + r.LastName
                         };

            var teams = from t in Formula1.GetConstructorChampions()
                        from y in t.Years
                        select new
                        {
                            Year = y,
                            Name = t.Name
                        };

            var racersAndTeams =
                  (from r in racers
                   join t in teams on r.Year equals t.Year
                   orderby t.Year
                   select new
                   {
                       Year = r.Year,
                       Champion = r.Name,
                       Constructor = t.Name
                   }).Take(10);

            Console.WriteLine("Year  World Champion\t   Constructor Title");
            foreach (var item in racersAndTeams)
            {
                Console.WriteLine($"{item.Year}: {item.Champion,-20} {item.Constructor}");
            }
        }


        static void LeftOuterJoin()
        {
            var racers = from r in Formula1.GetChampions()
                         from y in r.Years
                         select new
                         {
                             Year = y,
                             Name = r.FirstName + " " + r.LastName
                         };

            var teams = from t in Formula1.GetConstructorChampions()
                        from y in t.Years
                        select new
                        {
                            Year = y,
                            Name = t.Name
                        };

            var racersAndTeams =
              (from r in racers
               join t in teams on r.Year equals t.Year into rt
               from t in rt.DefaultIfEmpty()
               orderby r.Year
               select new
               {
                   Year = r.Year,
                   Champion = r.Name,
                   Constructor = t == null ? "no constructor championship" : t.Name
               }).Take(10);

            Console.WriteLine("Year  Champion\t\t   Constructor Title");
            foreach (var item in racersAndTeams)
            {
                Console.WriteLine($"{item.Year}: {item.Champion,-20} {item.Constructor}");
            }
        }


        static void Aggregate()
        {
            var query = from r in Formula1.GetChampions()
                        let numberYears = r.Years.Count()
                        where numberYears >= 3
                        orderby numberYears descending, r.LastName
                        select new
                        {
                            Name = r.FirstName + " " + r.LastName,
                            TimesChampion = numberYears
                        };

            foreach (var r in query)
            {
                Console.WriteLine($"{r.Name} {r.TimesChampion}");
            }
        }

        static void Aggregate2()
        {
            var countries = (from c in
                                 from r in Formula1.GetChampions()
                                 group r by r.Country into c
                                 select new
                                 {
                                     Country = c.Key,
                                     Wins = (from r1 in c
                                             select r1.Wins).Sum()
                                 }
                             orderby c.Wins descending, c.Country
                             select c).Take(5);

            foreach (var country in countries)
            {
                Console.WriteLine($"{country.Country} {country.Wins}");
            }
        }

        static void Lookup()
        {
            var racers = (from r in Formula1.GetChampions()
                          from c in r.Cars
                          select new
                          {
                              Car = c,
                              Racer = r
                          }).ToLookup(cr => cr.Car, cr => cr.Racer);

            if (racers.Contains("Williams"))
            {
                foreach (var williamsRacer in racers["Williams"])
                {
                    Console.WriteLine(williamsRacer);
                }
            }
        }

    }
}
