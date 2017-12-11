using Core.Interface;
using Data.Base;
using Data.Base.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Newtonsoft.Json;
using System.Collections.Generic;
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

        public User GetUser(string id)
        {
            return _dataService.Select(id);
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

        public IList<User> GetUserByName(string name)
        {
            return _dataService.SearchUser(name);
        }

        public Message UpdatUser(User user)
        {
            var updateDefinitions = new List<UpdateDefinition<User>>();
            var json = JsonConvert.SerializeObject(user);
            var items = BsonSerializer.Deserialize<BsonDocument>(json).GetEnumerator();
            while (items.MoveNext())
            {
                if (!items.Current.Value.IsBsonNull)
                {
                    var i = items.Current;
                    updateDefinitions.Add(Builders<User>.Update.Set(i.Name, i.Value));
                }
            }
            var result =  _dataService.Update(user.Id,updateDefinitions.ToArray());
            return result > 0
                ? new Message() { Code = (int)MessageStatus.Success, Msg = $"{result}行数据修改成功" }
                : new Message() { Code = (int)MessageStatus.Error, Msg = "数据修改失败" };
        }
    }
}
