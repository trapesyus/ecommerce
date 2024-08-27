using ecommercedotnet.Models;

namespace ecommercedotnet.Abstract
{
    public interface IUserService
    {
        void AddUser(User newUser);
        List<User> GetUsers();
    }
}
