

using System;
using System.Data.Entity;
using System.Linq;

namespace Vidzy
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a query to load all the videos and display their genres
            using (var ctx = new VidzyContext())
            {
                //The N+1 Problem
                var vids = ctx.Videos.ToList();
                foreach (var v in vids)
                {
                    Console.WriteLine(v.Name + " -- " + v.Genre.Name);
                }

                Console.WriteLine();
            };

            //Eager Loading
            using (var ctx = new VidzyContext())
            {
                
                var vids = ctx.Videos.Include(v => v.Genre);
                foreach (var v in vids)
                {
                    Console.WriteLine(v.Name + " -- " + v.Genre.Name);
                }

                Console.WriteLine();
            }

            //Explicit Loading
            using(var ctx = new VidzyContext())
            {
                var vids = ctx.Videos.ToList();
                var vidIds = vids.Select(v => v.Id);
                ctx.Genres.Where(g => vidIds.Contains(g.Id)).Load();

                foreach (var v in vids)
                {
                    Console.WriteLine(v.Name + " -- " + v.Genre.Name);
                }
            }
            Console.Read();

        }
    }
}
