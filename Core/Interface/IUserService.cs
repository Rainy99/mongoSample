using System.Collections.Generic;
using Data.Base.Models;

namespace Core.Interface
{
    public interface IUserService
    {
        IList<User> GetUsers();

        User GetUser(string id);
        
        User AddUser(User user);

        Message DeleteUser(string id);
    }
}
