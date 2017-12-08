using System.Collections.Generic;
using Core.Enum;
using Core.Interface;
using Data.Base;
using Data.Base.Models;
using static Core.Enum.AppEnums;

namespace Core.Service
{
    public class UserService:IUserService
    {
        readonly DataService _dataService = new DataService();

        public IList<User> GetUsers()
        {
            return _dataService.Select();
        }

        public User AddUser(User user)
        {
            return _dataService.Add(user);
        }

        public Message DeleteUser(string id)
        {
            var result = _dataService.Delete(id);
            return result > 0
                ? new Message() {Code = (int) MessageStatus.Success, Msg = "删除成功"}
                : new Message() {Code = (int) MessageStatus.Error, Msg = "删除失败"};
        }
    }
}
