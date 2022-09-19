using BookRatingApi.Contracts.Repository;
using BookRatingApi.Entities;
using BookRatingApi.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookRatingApi.Repository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDapperRepository _dapper;

        public UserRepository(IDapperRepository dapper)
        {
            _dapper = dapper;
        }
        public async Task<Users> Login(LoginDTO loginDTO)
        {
            var parameters = new {
            @Username = loginDTO.Username,
            @Password = loginDTO.Password
            };
            var results = await _dapper.QuerySingleWithParameter<Users>("[dbo].[GetUserByUserNameAndPassword]",
               parameters);
            return results;
        }

        public int Register(RegisterDTO registerDTO)
        {
            var parameters = new
            {
                @FirstName = registerDTO.FirstName,
                @LastName = registerDTO.LastName,
                @UserName = registerDTO.UserName,
                @Email = registerDTO.Email,
                @Password = registerDTO.Password
            };
            var result = _dapper.Execute("[dbo].[RegisterUser]", parameters);
            return result;
        }
    }
}
