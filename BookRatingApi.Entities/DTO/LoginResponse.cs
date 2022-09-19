using System;
using System.Collections.Generic;
using System.Text;

namespace BookRatingApi.Entities.DTO
{
   public class LoginResponse
    {
        public int UserId { get; set; }
        public string  UserName { get; set; }
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public string StatusCode { get; set; }
    }
}
