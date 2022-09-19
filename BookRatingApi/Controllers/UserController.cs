using BookRatingApi.BLL.Utilities;
using BookRatingApi.Contracts.BLL;
using BookRatingApi.Entities.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRatingApi.Controllers
{
    public class UserController : Controller
    {
    private readonly IUserBLL _userBLL;

        public UserController(IUserBLL userBLL)
        {
            _userBLL = userBLL;
        }

        [HttpGet]
        [Route("Login")]
        public async Task<LoginResponse> Login(LoginDTO loginDTO)
        {
            try
            {
                if(string.IsNullOrEmpty(loginDTO.Username) || string.IsNullOrEmpty(loginDTO.Password))
                {
                    return new LoginResponse { IsSuccessful = false, StatusCode = CustomStatusCodes.ClientError, Message = CustomMessages.LoginClientError };
                }
                var result = _userBLL.Login(loginDTO);
                if(result == null)
                {
                    return new LoginResponse { IsSuccessful = false, StatusCode = CustomStatusCodes.InformationalStatus, Message= CustomMessages.UserNotFound};
                }
                return new LoginResponse { IsSuccessful = true, StatusCode = CustomStatusCodes.SuccessStatus, Message = CustomMessages.LoginSuccess, UserId=result.Result.UserId,UserName=result.Result.UserName };
            }
            catch (Exception ex)
            {
                return new LoginResponse { IsSuccessful = false, StatusCode = CustomStatusCodes.ServerError, Message = CustomMessages.ServerError};
            }
        }

        [HttpPost]
        [Route("Register")]
        public async Task<RegisterResponse> Register(RegisterDTO registerDTO)
        {
            try
            {
                if(string.IsNullOrEmpty(registerDTO.FirstName) || string.IsNullOrEmpty(registerDTO.LastName) || string.IsNullOrEmpty(registerDTO.Email) || string.IsNullOrEmpty(registerDTO.Password))
                {
                    return new RegisterResponse { IsSuccessful = false, StatusCode = CustomStatusCodes.ClientError, Message = CustomMessages.RegisterClientError };
                }
                var result = _userBLL.Register(registerDTO);
                if(result == -1)
                {
                    return new RegisterResponse { IsSuccessful = true, StatusCode = CustomStatusCodes.SuccessStatus , Message = CustomMessages.RegisterSuccess};
                }
                    return new RegisterResponse { IsSuccessful = false, StatusCode = CustomStatusCodes.InformationalStatus, Message = CustomMessages.UserExits };
            }
            catch (Exception ex)
            {
                    return new RegisterResponse { IsSuccessful = false, StatusCode = CustomStatusCodes.ServerError, Message = CustomMessages.ServerError };
            }
        }
    }
}
