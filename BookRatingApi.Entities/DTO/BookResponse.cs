using System;
using System.Collections.Generic;
using System.Text;

namespace BookRatingApi.Entities.DTO
{
   public class BookResponse
    {
        public bool IsSuccessful { get; set; }
        public IEnumerable<BookInfo> Books { get; set; }
        public string Message { get; set; }
        public string SatusCode { get; set; }
    }
}
