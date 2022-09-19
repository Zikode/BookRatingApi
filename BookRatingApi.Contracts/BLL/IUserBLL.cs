using BookRatingApi.Entities;
using BookRatingApi.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookRatingApi.Contracts.BLL
{
    public interface IUserBLL
    {
        public Task<Users> Login(LoginDTO loginDTO);
        public int Register(RegisterDTO registerDTO);
    }
}
