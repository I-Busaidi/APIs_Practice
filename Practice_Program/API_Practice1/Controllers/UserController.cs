using API_Practice1.Services;
using API_Practice1.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Practice1.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            try
            {
                var users = _userService.GetAllUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetUserById/{id}")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                var user = _userService.GetUserById(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetUsersByName/{name}")]
        public IActionResult GetUsersByName(string name)
        {
            try
            {
                var users = _userService.GetUsersByName(name);
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddUser(string fname, string? lname, string? gender, string email, string password)
        {
            try
            {
                _userService.AddUser(new User
                {
                    FName = fname,
                    LName = lname,
                    Gender = gender,
                    Email = email,
                    Passcode = password
                });
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}/UpdateUser")]
        public IActionResult UpdateUser(int id, string fname, string? lname, string? gender, string email, string password)
        {
            try
            {
                _userService.UpdateUser(id, new User
                {
                    FName = fname,
                    LName = lname,
                    Gender = gender,
                    Email = email,
                    Passcode = password
                });
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                _userService.RemoveUser(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
