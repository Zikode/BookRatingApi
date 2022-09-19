using BookRatingApi.BLL.Utilities;
using BookRatingApi.Contracts.BLL;
using BookRatingApi.Entities;
using BookRatingApi.Entities.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRatingApi.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookBLL bookBLL;
        public BooksController(IBookBLL _bookBLL)
        {
            bookBLL = _bookBLL;
        }

       [HttpGet]
       [Route("GetBooks")]
       public async Task<BookResponse> GetAllBooks()
        {
            try
            {
                var results = await bookBLL.GetAllBooks();
                if (results == null)
                {
                    return new BookResponse { IsSuccessful = false, SatusCode = CustomStatusCodes.ClientError, Message = CustomMessages.NoBooksFound };
                }
                return new BookResponse { IsSuccessful = true, SatusCode = CustomStatusCodes.SuccessStatus, Books = results, Message = CustomMessages.BooksFound };
            }
            catch (Exception ex)
            {
                return new BookResponse {IsSuccessful = false, SatusCode = CustomStatusCodes.ServerError, Message = CustomMessages.ServerError};
            }
        }

        [HttpGet]
        [Route("GetBookById")]
        public async Task<BookResponse> GetBookById(int bookId)
        {
            try
            {
            var results = await bookBLL.GetBookById(bookId);

            if (results == null)
            {
                return new BookResponse {IsSuccessful = false, SatusCode = CustomStatusCodes.ClientError, Message = CustomMessages.NoBooksFound };
            }
            return new BookResponse {IsSuccessful = true, SatusCode = CustomStatusCodes.SuccessStatus, Message = CustomMessages.BooksFound };
        }
            catch (Exception ex)
            {
                return new BookResponse {IsSuccessful = false, SatusCode = CustomStatusCodes.ServerError, Message = CustomMessages.ServerError};
        }
        }

        [HttpGet]
        [Route("SearchBook")]
        public async Task<BookResponse> SearchForABook(string searchString)
        {
            try
            {
                var results = await bookBLL.SearchForBookBySearchString(searchString);
                if(results == null)
                {
                    return new BookResponse {IsSuccessful = false, SatusCode = CustomStatusCodes.ClientError, Message = CustomMessages.NoBooksFound};
                }
                return new BookResponse { IsSuccessful = true, Books = results, SatusCode = CustomStatusCodes.SuccessStatus, Message = CustomMessages.BooksFound };
            }
            catch (Exception ex)
            {
                return new BookResponse { IsSuccessful = false, SatusCode = CustomStatusCodes.ServerError, Message = CustomMessages.ServerError };
            }
        }

        [HttpPost]
        [Route("AddBook")]
        public async Task<BookResponse> InsertBook(BookDTO bookDTO)
        {
            try
            {
                var results = bookBLL.InsertBook(bookDTO);
                if(string.IsNullOrEmpty(bookDTO.Title) || string.IsNullOrEmpty(bookDTO.Author) || string.IsNullOrEmpty(bookDTO.Summary)){
                    return new BookResponse { SatusCode = CustomStatusCodes.ClientError, IsSuccessful = false, Message = CustomMessages.BoosksClientError };
                }
                if(results == -1)
                {
                    return new BookResponse { SatusCode = CustomStatusCodes.SuccessStatus, IsSuccessful = true, Message = CustomMessages.BoosksInsertSuccess };
                }
                return new BookResponse { SatusCode = CustomStatusCodes.InformationalStatus, IsSuccessful = false };
            }
            catch (Exception ex)
            {
                return new BookResponse { SatusCode = CustomStatusCodes.ServerError, IsSuccessful = false, Message = CustomMessages.ServerError};
            }
        }

        [HttpPut]
        [Route("ModifyBook")]
        public async Task<BookResponse> UpdateBook(BookInfo bookInfo)
        {
            try
            {
                var results = bookBLL.UpdateBookInfo(bookInfo);
                if (string.IsNullOrEmpty(bookInfo.Title) || string.IsNullOrEmpty(bookInfo.Author) || string.IsNullOrEmpty(bookInfo.Summary) || string.IsNullOrEmpty(bookInfo.ISBN))
                {
                    return new BookResponse { IsSuccessful = false, SatusCode = CustomStatusCodes.ClientError, Message = CustomMessages.BoosksClientError };
                }
                if(results == -1)
                {
                    return new BookResponse {IsSuccessful = true, SatusCode = CustomStatusCodes.SuccessStatus, Message = CustomMessages.BoosksUpdateSuccess};
                }
                return new BookResponse { IsSuccessful = false, SatusCode = CustomStatusCodes.InformationalStatus, Message = CustomMessages.FailedToUpdateBook};
            }
            catch (Exception)
            {
                return new BookResponse { IsSuccessful = false, SatusCode = CustomStatusCodes.ServerError, Message = CustomMessages.ServerError };
            }
           
        }
    }
}
