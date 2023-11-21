using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample_Serializer.Domain
{
    public class Book
    {
        public int BookId { get; set; }
        public string? Name { get; set; }
        public string? DateofPublish { get; set; }
        public string? Author { get; set; } 
        public int Price { get; set; }

    }
}