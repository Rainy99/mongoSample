using Core.Interface;
using Data.Base.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("[controller]/[action]")]
    [EnableCors("any")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IList<User> Users()
        {
            return _userService.GetUsers();
        }

        [HttpGet]
        public IList<User> Search(string name)
        {
            return _userService.GetUserByName(name);
        }

        [HttpGet("{id}")]
        public User Detail(string id)
        {
            return _userService.GetUser(id);
        }

        [HttpPost]
        public User Users([FromBody]User user)
        {
            return _userService.AddUser(user);
        }
        
        [HttpDelete]
        public Message Users(string id)
        {
            return _userService.DeleteUser(id);
        }

        [HttpPut]
        public Message Update([FromBody]User user)
        {
            return _userService.UpdatUser(user);
        }
    }
}