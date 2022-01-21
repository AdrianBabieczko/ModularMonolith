using Confab.Modules.Users.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Confab.Modules.Users.Core.DAL.Repositories
{
    public class UserRepository
    {
        private readonly UsersDbContext _context;
        private readonly DbSet<User> _users;

        public UserRepository(UsersDbContext context)
        {
            _context = context;
            _users = _context.Users;
        }
    }
}