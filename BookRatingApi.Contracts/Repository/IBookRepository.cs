using BookRatingApi.Entities;
using BookRatingApi.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookRatingApi.Contracts.Repository
{
   public interface IBookRepository
    {
        public int InsertBook(BookDTO bookDTO);

        public Task<IEnumerable<BookInfo>> GetAllBooks();

        public Task<BookInfo> GetBookById(int BookId);
        public Task<IEnumerable<BookInfo>> SearchForBookBySearchString(string SearchString);

        public int UpdateBookInfo(BookInfo bookInfo);

    }
}
