using System;
using System.Collections.Generic;
using System.Text;

namespace BookRatingApi.Entities
{
    public class BookInfo
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Summary { get; set; }
        public string ISBN { get; set; }
        public DateTime DateReleased { get; set; }
        public int FK_UserId { get; set; }
    }
}
