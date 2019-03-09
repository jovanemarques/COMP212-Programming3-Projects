using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstNewDBSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new BloggingContext();
            Console.Write("Enter a name for a new Blog:");

            var name = Console.ReadLine();

            var blog = new Blog { Name = name };

            db.Blogs.Add(blog);
            db.SaveChanges();

            var query = from b in db.Blogs
                        orderby name
                select b;

            Console.WriteLine("All blogs in the database:");
            foreach (var item in query)
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadKey();
        }
    }
}
