using Common.Enums;
using Microsoft.EntityFrameworkCore;
using Test.Data;
using Test.Data.Entities;
using TestWebAPI.Models.Requests;
using TestWebAPI.Models.Responses;
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

        public BookBorrowingRequest? Approve(int id, ApproveBookRequest approveRequestModel, User approver)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == approver.UserId);

            var bookBorrowingRequest = _context.BookBorrowingRequests.FirstOrDefault(r => r.RequestId == id);

            if(bookBorrowingRequest != null && bookBorrowingRequest.Status == RequestBookStatus.Waiting)
            {
                bookBorrowingRequest.Status = approveRequestModel.Status;
                bookBorrowingRequest.Approver = approver;

                _context.Update(bookBorrowingRequest);
                _context.SaveChanges();

                return bookBorrowingRequest;
            }

            return null;
        }

        public BookBorrowingRequest Create(BookRequest bookRequestModel, User requestUser)
        {
            var bookBorrowingRequest = new BookBorrowingRequest
            {
                RequestUser = requestUser,
                BorrowingDate = DateTime.Now,
                Status = RequestBookStatus.Waiting
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
