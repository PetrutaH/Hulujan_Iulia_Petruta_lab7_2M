using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hulujan_Iulia_Petruta_Lab2M.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }

        // public string Author { get; set; }
        public decimal Price { get; set; }
        public int? GenreID { get; set; }
       
        public Genre? Genre { get; set; }

        public int? AuthorID { get; set; }

        public Author? Author { get; set; }


        public ICollection<Order>? Orders { get; set; }
    }
}
