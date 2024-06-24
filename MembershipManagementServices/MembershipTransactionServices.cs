using MembershipManagementData;
using MembershipManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipManagementServices
{
    public class MembershipTransactionServices
    {
        MembershipValidationServices validationServices = new MembershipValidationServices();
        MemberData userData = new MemberData();

        public bool CreateUser(Member user)
        {
            bool result = false;

            if (validationServices.CheckIfUserNameExists(user.username))
            {
                result = userData.AddUser(user) > 0;
            }

            return result;
        }

        public bool CreateUser(string username, string password)
        {
            Member user = new Member { username = username, password = password };

            return CreateUser(user);
        }

        public bool UpdateUser(Member user)
        {
            bool result = false;

            if (validationServices.CheckIfUserNameExists(user.username))
            {
                result = userData.UpdateUser(user) > 0;
            }

            return result;
        }

        public bool UpdateUser(string username, string password)
        {
            Member user = new Member { username = username, password = password };

            return UpdateUser(user);
        }

        public bool DeleteUser(Member user)
        {
            bool result = false;

            if (validationServices.CheckIfUserNameExists(user.username))
            {
                result = userData.DeleteUser(user) > 0;
            }

            return result;
        }
    }
}
