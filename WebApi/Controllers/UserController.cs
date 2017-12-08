using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interface;
using Core.Service;
using Data.Base.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}