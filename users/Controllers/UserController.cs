using Microsoft.AspNetCore.Mvc;
using users.ApiContracts;
using users.Models;
using users.Services;

namespace users.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult CreateUser(CreateUserRequest request)
        {
            if(_userService.GetUser(request.Email) != null)
            {
                return Conflict(request.Email + " already exists!");
            }

            User newUser = new User
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                HashedPassword = request.Password,
            };

            // call service
            _userService.CreateUser(newUser);

            UserResponse response = new(
                request.FirstName,
                request.LastName,
                request.Email
            );
            return CreatedAtAction(nameof(GetUser), new { email = request.Email }, response);
        }

        [HttpGet("{email}")]
        public IActionResult GetUser(string email)
        {
            User? user = _userService.GetUser(email);
            if (user == null)
            {
                return NotFound(email);
            }
            else
            {
                UserResponse response = new(Email: user.Email, FirstName: user.FirstName, LastName: user.LastName);
                return Ok(response);
            }
        }

        [HttpDelete]
        public IActionResult DeleteUser(string email)
        {
            User? user = _userService.GetUser(email);
            if (user == null)
            {
                return NotFound(email);
            }
            else
            {
                _userService.DeleteUser(email);
                return Ok();
            }
        }

        [HttpPut]
        public IActionResult UpdateUser(UpdateUserRequest request)
        {
            if (_userService.GetUser(request.Email) == null)
            {
                return NotFound(request.Email + " not found!");
            }

            _userService.UpdateUser(request.Email, request.FirstName, request.LastName);
            return Ok();
        }

        [HttpPost("login")]
        public IActionResult VerifyUser(VerifyCredentialsRequest request)
        {
            bool allowed = _userService.VerifyCredentials(request.Email, request.Password);
            return Ok(new VerifyCredentialsResponse(allowed));
        }
    }
}
