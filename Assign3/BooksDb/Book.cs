﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksDb
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual List<Author> Authors { get; set; }
    }
}
