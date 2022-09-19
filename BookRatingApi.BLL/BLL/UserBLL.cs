using BookRatingApi.Contracts.BLL;
using BookRatingApi.Contracts.Repository;
using BookRatingApi.Entities;
using BookRatingApi.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookRatingApi.BLL.BLL
{
  public class UserBLL : IUserBLL
    {
        private readonly IUserRepository _userRepository;
        public UserBLL(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<Users> Login(LoginDTO loginDTO)
        {
            loginDTO.Password = Utilities.Utilities.EncrpytPassword(loginDTO.Password);
            return _userRepository.Login(loginDTO);
        }

        public int Register(RegisterDTO registerDTO)
        {
            registerDTO.UserName = Utilities.Utilities.GenerateUserName(registerDTO.FirstName, registerDTO.LastName);
            registerDTO.Password = Utilities.Utilities.EncrpytPassword(registerDTO.Password);
            return _userRepository.Register(registerDTO);
        }
    }
}
