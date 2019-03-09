using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Country> countries = Country.GetCountries();

            //1.1	List the names of the countries in alphabetical order [0.5 mark]
            countries.OrderBy(c => c.Name);
            printIt(countries);
            
            //1.2 List the names of the countries in descending order of number of resources[0.5 mark]
            countries.OrderByDescending(c => c.Resources);
            printIt(countries);
            
            //1.3 List the names of the countries that shares a border with Argentina[0.5 mark]
            countries.Where(c => c.Borders.Equals("Argentina"));
            printIt(countries);
            
            //1.4 List the names of the countries that has more than 10,000,000 population[0.5 mark]
            countries.Where(c => c.Population > 10000000);
            printIt(countries);
            
            //1.5 List the country with highest population[1 mark]
            //countries.Where(c => c.Population.Equals(c.Population.Max()));
            printIt(countries);
            
            //1.6 List all the religion in south America in dictionary order[1 mark]
            var religions = countries.Select(c => new { Religions = c.Religions });
            Console.WriteLine(religions);
            Console.ReadKey();
        }

        private static void printIt(List<Country> countries)
        {
            foreach (var item in countries)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("");
        }
    }
}
