
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Vidzy
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new VidzyContext())
            {
                //var genres = ctx.Genres.ToList();
//                //1 Add a new video called "Terminator 1" with action genre, release date Oct 26 198 with silver classification
//                ctx.Videos.Add(new Video()
//                {
//                    Classification = Classification.Silver,
//                    Genre = genres.Find(p => p.Name == "Action"),
//                    Name = "Terminator 1",
//                    ReleaseDate = new DateTime(1984, 10, 26)
//                });
                  
                  //2 Add two tags "Classics" and "Drama" to the database. 
//                ctx.Tags.AddRange(new List<Tag>()
//                {
//                    new Tag
//                    {
//                        Name = "Classics"
//                    },
//                    new Tag()
//                    {
//                        Name = "Drama"
//                    }
//                });
                //add three tags classics, drama, comdedy to the video with id 1. 
//                var vid = ctx.Videos.Single(v => v.Id == 1);
//                var tags = ctx.Tags.ToList();
//                vid.Tags.Add(tags.Find(t => t.Id == 1));
//                vid.Tags.Add(tags.Find(t => t.Id == 2));
//                vid.Tags.Add(tags.Find(t => t.Id == 3));
//                ctx.SaveChanges();

                //Remove the comedy tag from the video id=1
//                var tags = ctx.Tags.ToList();
//                var vid = ctx.Videos.Find(1);
//                vid.Tags.Remove(tags.Find(t =>t.Id == 3));
//                ctx.SaveChanges();






            }
        }
    }
}
