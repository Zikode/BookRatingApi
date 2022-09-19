using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookRatingApi.Entities.DTO
{
    public class BookDTO
    {
        public string Title { get; set; }
        public string Author { get; set; }
        
        [MaxLength(200)]
        public string Summary { get; set; }
        public string ISBN { get; set; }
        public DateTime DateReleased { get; set; }
        public int UserId { get; set; }
    }
}
