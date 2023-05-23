using MappyUserApi.Models;
using MappyUserApi.Models.Requests;
using MappyUserApi.Models.Responses;
using MappyUserApi.Services;
using MappyUserApi.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace MappyUserApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {

    //=============================================================================================
    private readonly UserService _userService;


    //=============================================================================================
    public UserController(UserService userService)
    {
      _userService = userService;
    }


    //=============================================================================================
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(string id)
    {
      var user = await _userService.GetAsync(new Guid(id));

      if (user == null)
      {
        return NotFound(new { message = $"No user with id {id} exist!" });
      }
      else
      {
        return Ok(new SecureUserModel {
          Id = user.Id,
          Email = user.Email,
          Username = user.Username
        });
      }
    }

    //=============================================================================================
    [HttpGet("email/{email}")]
    public async Task<IActionResult> GetUserByEmail(string email)
    {
      var user = await _userService.GetAsync(email);

      if (user == null)
      {
        return NotFound(new { message = $"No user with email {email} exist!" });
      }
      else
      {
        return Ok(new SecureUserModel {
          Id = user.Id,
          Email = user.Email,
          Username = user.Username
        });
      }
    }

    //=============================================================================================
    [HttpPost("login")]
    public async Task<IActionResult> LoginUser(LoginUserModel model)
    {
      var user = await _userService.GetAsync(model.Email);

      if (user == null)
      {
        return NotFound(new { message = $"No user with email {model.Email} exist!" });
      }
      else
      {
        var hashedPassword = AuthenticationHelper.HashPassword(model.Password);

        if (hashedPassword.Equals(user.Password))
        {
          return Ok(new SecureUserModel {
            Id = user.Id,
            Email = user.Email,
            Username = user.Username
          });
        }
        else
        {
          return BadRequest(new { message = "Wrong password!" });
        }
      }
    }

    //=============================================================================================
    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser(RegisterUserModel model)
    {
      if (await _userService.ExistByEmail(model.Email))
      {
        return BadRequest(new { message = $"User with email {model.Email} already exist!" });
      }

      var hashedPassword = AuthenticationHelper.HashPassword(model.Password);

			var result = await _userService.AddAsync(new UserModel {
				Username = model.Username,
				Email = model.Email,
				Password = hashedPassword
			});

      return Ok(new { isAdded = result });
    }
  }
}