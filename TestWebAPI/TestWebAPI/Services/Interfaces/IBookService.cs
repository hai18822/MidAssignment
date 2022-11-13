using Test.Data.Entities;
using TestWebAPI.Models.Requests;
using TestWebAPI.Models.Responses;

namespace TestWebAPI.Services.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookResponse>> Get();

        Task<Book?> Get(int id);

        Task<AddBookResponse> Add(AddBookRequest bookToAdd);
        Book Update(int id, UpdateBookRequest bookToUpdate);
        bool Delete(int id);
        bool SoftDelete(int id);

        Task InitData();

    }
}
