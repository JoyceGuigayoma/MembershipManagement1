using MembershipManagementServices;
using MembershipManagement.API;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using MembershipManagementModels;

namespace AccountManagement.API.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : Controller
    {
        MembershipGetServices _userGetServices;
        MembershipTransactionServices _userTransactionServices;

        public UserController()
        {
            _userGetServices = new MembershipGetServices();
            _userTransactionServices = new MembershipTransactionServices();
        }

        [HttpGet]
        public IEnumerable<MembershipManagement.API.User> GetUsers(int? recruitStatus = null)
        {
            IEnumerable<Member> activeUsers;

            if (recruitStatus.HasValue)
            {
                activeUsers = _userGetServices.GetUsersByRecruit(recruitStatus.Value);
            }
            else
            {
                activeUsers = _userGetServices.GetAllUsers();
            }

            Console.WriteLine($"Number of active users: {activeUsers.Count()}");

            List<MembershipManagement.API.User> users = new List<MembershipManagement.API.User>();

            foreach (var item in activeUsers)
            {
                users.Add(new MembershipManagement.API.User
                {
                    username = item.username,
                    password = item.password,
                    recruit = item.recruit
                });
            }

            return users;
        }



        [HttpPost]
        public IActionResult AddUser(MembershipManagement.API.User request)
        {
            bool result = _userTransactionServices.CreateUser(request.username, request.password, request.recruit);

            if (result)
            {
                return Ok("User added successfully");
            }
            else
            {
                return BadRequest("Failed to add user");
            }
        }



        [HttpPatch("{username}")]
        public IActionResult UpdateUser(string username, [FromBody] MembershipManagement.API.User user)
        {
            if (user == null)
            {
                return BadRequest("User data is null.");
            }

            bool result = _userTransactionServices.UpdateUser(username, user.password, user.recruit);

            if (result)
            {
                return Ok("User updated successfully");
            }
            else
            {
                return BadRequest("Failed to update user");
            }
        }


        [HttpDelete("{username}")]
        public IActionResult DeleteUser(string username, string password)
        {
            bool result = _userTransactionServices.DeleteUser(username, password);

            if (result)
            {
                return Ok($"User '{username}' deleted successfully");
            }
            else
            {
                return NotFound($"User '{username}' not found or failed to delete");
            }
        }

    }
}