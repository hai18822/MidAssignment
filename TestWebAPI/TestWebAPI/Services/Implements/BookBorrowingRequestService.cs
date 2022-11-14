using Microsoft.EntityFrameworkCore;
using Test.Data;
using Test.Data.Entities;
using TestWebAPI.Models.Requests;
using TestWebAPI.Services.Interfaces;

namespace TestWebAPI.Services.Implements
{
    public class BookBorrowingRequestService : IBookBorrowingRequestService
    {
        private TestContext _context;

        public BookBorrowingRequestService(TestContext context)
        {
            _context = context;
        }

        public BookBorrowingRequest Create(BookRequest bookRequestModel, User requestUser)
        {
            var bookBorrowingRequest = new BookBorrowingRequest
            {
                RequestUser = requestUser,
                BorrowingDate = DateTime.Now,
                Status = false
            };

            var books = _context.Books.Where(b => bookRequestModel.BookIds.Contains(b.BookId)).ToList();

            if (books != null && bookRequestModel.BookIds.Count != 0)
            {
                _context.Add(bookBorrowingRequest);
                _context.SaveChanges();

                return bookBorrowingRequest;
            }

            return null;
        }
    }
}
