using Test.Data.Entities;
using TestWebAPI.Models.Requests;
using TestWebAPI.Models.Responses;

namespace TestWebAPI.Services.Interfaces
{
    public interface IBookBorrowingRequestService
    {
        BookBorrowingRequest Create(BookRequest bookRequestModel, User requestUser);
    }
}
