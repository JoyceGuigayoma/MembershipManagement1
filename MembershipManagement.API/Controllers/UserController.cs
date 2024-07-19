using MembershipManagementServices;
using MembershipManagement.API;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

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
        public IEnumerable<MembershipManagement.API.User> GetUsers()
        {
            var activeusers = _userGetServices.GetUsersByStatus(1);

            List<MembershipManagement.API.User> users = new List<User>();

            foreach (var item in activeusers)
            {
                users.Add(new MembershipManagement.API.User { username = item.username, password = item.password });
            }

            return users;
        }

        [HttpPost]
        public JsonResult AddUser(User request)
        {
            var result = _userTransactionServices.CreateUser(request.username, request.password);

            return new JsonResult(result);
        }

        [HttpPatch]
        public JsonResult UpdateUser(User request)
        {
            var result = _userTransactionServices.UpdateUser(request.username, request.password);

            return new JsonResult(result);
        }


    }
}
