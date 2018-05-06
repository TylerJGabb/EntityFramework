

using System;
using System.Linq;

namespace Vidzy
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new VidzyContext())
            {
                var genres = ctx.Genres.ToList();

                Console.WriteLine("===========Action movies sorted by name");
                var actnMoviesByName = ctx.Videos
                    .Where(v => v.GenreId == 2)
                    .OrderBy(v => v.Name);
                foreach (var video in actnMoviesByName)
                {
                    Console.WriteLine(video.Name);
                }

                Console.WriteLine();

                Console.WriteLine("===========Drama movies sorted by release date");
                var dramaMoviesByReleaseDateDesc = ctx.Videos
                    .Where(v => v.Classification == Classification.Gold && v.GenreId == 7)
                    .OrderByDescending(v => v.ReleaseDate);
                foreach (var video in dramaMoviesByReleaseDateDesc)
                {
                    Console.WriteLine(video.Name);
                }

                Console.WriteLine();

                Console.WriteLine("========All movies projected into an anonymous type with two properties: MovieName and Genre");
                var projection = ctx.Videos.Select(
                    m => new
                    {
                        Name = m.Name,
                        Genre = m.Genre.Name
                    });
                foreach (var x1 in projection)
                {
                    Console.WriteLine(x1.Name + ":" + x1.Genre);
                }

                Console.WriteLine();

                Console.WriteLine("========All movies grouped by classification");
                var query =
                    from v in ctx.Videos
                    group v by v.Classification
                    into g
                    select g;
                foreach (var g in query.OrderBy(g => g.Key))
                {
                    Console.WriteLine("\t" + g.Key.ToString() + ":");
                    foreach (var video in g.OrderBy(v => v.Name))
                    {
                        Console.WriteLine("\t" + video.Name);
                    }

                    Console.WriteLine();
                }

                Console.WriteLine();

                Console.WriteLine("========List of Classifications sorted alphabetically and their video count");
                var query2 =
                    from v in ctx.Videos
                    group v by v.Classification
                    into g
                    select new
                    {
                        Classification = g.Key.ToString(),
                        Count = g.Count()
                    };
                foreach (var g in query2.OrderBy(g => g.Classification))
                {
                    Console.WriteLine(g.Classification + $"({g.Count})");
                }

                Console.WriteLine();

                Console.WriteLine("=======List of Genres and number of videos they include, sorted by video count");
                var query3 =
                    from gen in ctx.Genres
                    select new
                    {
                        Genre = gen.Name,
                        Count = gen.Videos.Count()
                    };
                foreach (var obj in query3.OrderByDescending(o => o.Count))
                {
                    Console.WriteLine(obj.Genre + $"({obj.Count})");
                }

            }
        }
    }
}
