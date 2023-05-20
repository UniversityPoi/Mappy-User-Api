using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MappyUserApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MappyUserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserController()
        {

        }

        [HttpGet("")]
        public ActionResult<IEnumerable<UserModel>> GetUsers()
        {
            return new List<UserModel> { };
        }

        [HttpGet("{id}")]
        public ActionResult<UserModel> GetUserById(int id)
        {
            return null;
        }

        [HttpPost("")]
        public ActionResult<bool> PostUser(RegisterUserModel model)
        {
            return null;
        }

        [HttpPut("{id}")]
        public IActionResult PutUser(int id, UserModel model)
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<UserModel> DeleteUserById(int id)
        {
            return null;
        }
    }
}