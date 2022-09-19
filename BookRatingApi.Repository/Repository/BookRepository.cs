using BookRatingApi.Contracts.Repository;
using BookRatingApi.Entities;
using BookRatingApi.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookRatingApi.Repository.Repository
{
  public  class BookRepository : IBookRepository
    {
        private readonly IDapperRepository dapperRepository;
        public BookRepository(IDapperRepository _dapperRepository)
        {
            dapperRepository = _dapperRepository;
        }

        public async Task<IEnumerable<BookInfo>> GetAllBooks()
        {
            var results =  await dapperRepository.Query<BookInfo>("[dbo].[GetAllBooks]");
            return results;
        }

        public async Task<BookInfo> GetBookById(int bookId)
        {
            var parameters = new
            {
                @BookId = bookId
            };

            var results = await dapperRepository.QuerySingleWithParameter<BookInfo>("[dbo].[GetBookById]", parameters);
            return results;
        }

        public int InsertBook(BookDTO bookDTO)
        {
            var parameters = new
            {
                @Title = bookDTO.Title,
                @Author = bookDTO.Author,
                @Summary = bookDTO.Summary,
                @ISBN = bookDTO.ISBN,
                @DateReleased = bookDTO.DateReleased,
                @FK_UserId = bookDTO.UserId
            };
            var results = dapperRepository.Execute("[dbo].[InsertBook]", parameters);
            return results;
        }

        public Task<IEnumerable<BookInfo>> SearchForBookBySearchString(string searchString)
        {
            var parameters = new
            {
                @Searchstring = searchString
            };
            var result = dapperRepository.QueryWithParameter<BookInfo>("[dbo].[SearchBookBySearchSrtring]", parameters);
            return result;
        }

        public int UpdateBookInfo(BookInfo bookInfo)
        {
            var parameters = new
            {
                @Title = bookInfo.Title,
                @Author = bookInfo.Author,
                @Summary = bookInfo.Summary,
                @ISBN = bookInfo.ISBN,
                @DateReleased = bookInfo.DateReleased,
                @BookId = bookInfo.BookId
            };
            var results = dapperRepository.Execute("[dbo].[UpdateBookInfo]", parameters);
            return results;
        }
    }
}
