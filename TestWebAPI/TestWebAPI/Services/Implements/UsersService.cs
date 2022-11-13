using Microsoft.EntityFrameworkCore;
using Test.Data;
using Test.Data.Entities;
using TestWebAPI.Services.Interfaces;
using TestWebAPI.Services.Interfaces;

namespace TestWebAPI.Services.Implements
{
    public class UsersService : IUsersService
    {
        private readonly TestContext _context;

        public UsersService(TestContext context)
        {
            _context = context;
        }

        public async Task<User?> LoginUser(string username, string password)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.UserName == username && x.Password == password);
        }
    }
}
