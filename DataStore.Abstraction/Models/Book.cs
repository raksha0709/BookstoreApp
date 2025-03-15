using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStore.Abstraction.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public int Stock {  get; set; }
        public string? Description { get; set; }
        public DateTime PublishedDate { get; set; }
        public string? ImageUrl {  get; set; }

    }
}
