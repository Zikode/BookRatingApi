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
   public class BookBLL : IBookBLL
    {
        private readonly IBookRepository bookRepository;
        public BookBLL(IBookRepository _bookRepository)
        {
            bookRepository = _bookRepository;
        }
        public Task<IEnumerable<BookInfo>> GetAllBooks()
        {
            return bookRepository.GetAllBooks();
        }

        public Task<BookInfo> GetBookById(int BookId)
        {
            return bookRepository.GetBookById(BookId);
        }

        public int InsertBook(BookDTO bookDTO)
        {
            return bookRepository.InsertBook(bookDTO);
        }

        public Task<IEnumerable<BookInfo>> SearchForBookBySearchString(string SearchString)
        {
            return bookRepository.SearchForBookBySearchString(SearchString);
        }

        public int UpdateBookInfo(BookInfo bookInfo)
        {
            return bookRepository.UpdateBookInfo(bookInfo);
        }
    }
}
