using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MappyUserApi.Models;
using MappyUserApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace MappyUserApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private readonly UserService _userService;
    public UserController(UserService userService)
    {
      _userService = userService;
    }

    [HttpGet("")]
    public ActionResult<IEnumerable<UserModel>> GetUsers()
    {
			return new List<UserModel> { };
    }

    [HttpGet("{id}")]
    public ActionResult<UserModel> GetUserById(Guid id)
    {
      return null;
    }

    [HttpPost("")]
    public async Task<ActionResult<bool>> PostUser(RegisterUserModel model)
    {
			var result = await _userService.AddAsync(new UserModel {
				Username = model.Username,
				Email = model.Email,
				Password = model.Password
			});

      return Ok(new { isAdded = result });
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