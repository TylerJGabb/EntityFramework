﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VidzyCodeFirst.Models
{
    class Genre
    {
        public Genre()
        {
            Videos = new List<Video>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Video> Videos { get; set; }

    }
}