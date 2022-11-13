using Test.Data.Entities;

namespace TestWebAPI.Services.Interfaces
{
    public interface IUsersService
    {
        Task<User?> LoginUser(string username, string password);
        User GetUserById(Guid userId);
    }
}
