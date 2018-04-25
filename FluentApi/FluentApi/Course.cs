using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FluentApi
{
    public class Course
    {

        public Course()
        {
            Tags = new List<Tag>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }
        public float FullPrice { get; set; }
        public Author Author { get; set; }
        public Cover Cover { get; set; }


        public int AuthorId { get; set; }
        public IList<Tag> Tags { get; set; }
    }
}
