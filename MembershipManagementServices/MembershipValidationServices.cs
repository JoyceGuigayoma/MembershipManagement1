using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipManagementServices
{
    public class MembershipValidationServices
    {
        private MembershipGetServices getServices;

        public MembershipValidationServices()
        {
            getServices = new MembershipGetServices();
        }

        public bool CheckIfUserNameExists(string username, string password, int recruit)
        {

            bool isUsernameValid = true;
            bool isCombinationValid = true;

            if (isUsernameValid && isCombinationValid)
            {
                Console.WriteLine($"Username '{username}' does not exist and combination is valid.");
                return true;
            }
            else
            {
                Console.WriteLine($"Username '{username}' already exists or combination is invalid.");
                return false;
            }
        }



        public bool CheckIfUserExists(string username, string password)
        {
            return getServices.AuthenticateUser(username, password) != null;
        }
    }
}
