using Backend.Models;

namespace Backend.Interfaces
{
    public interface IUser
    {
        Task<User> RegisterUser(User user);
    }
}