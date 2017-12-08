using System.Collections.Generic;
using Data.Base.Models;

namespace Core.Interface
{
    public interface IUserService
    {
        IList<User> GetUsers();
        User AddUser(User user);

        Message DeleteUser(string id);
    }
}
