using ecommercedotnet.Abstract;
using ecommercedotnet.Models;
using System;

namespace ecommercedotnet.Concrete
{
    public class UserManager : IUserService
    {
        private readonly YourDbContext _context;

        public UserManager(YourDbContext context)
        {
            _context = context;
        }

        public List<User> GetUsers()
        {
            var userList = _context.Users.ToList();
            return userList;
        }

        public void AddUser(User newUser)
        {
            newUser.CreatedAt = DateTime.Now;
            newUser.UpdatedAt = DateTime.Now;
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }
    }
}
