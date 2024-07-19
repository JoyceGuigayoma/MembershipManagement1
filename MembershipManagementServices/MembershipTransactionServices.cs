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
            if (validationServices.CheckIfUserNameExists(user.username, user.password, user.recruit))
            {
                return userData.AddUser(user) > 0;
            }
            return false;
        }



        public bool CreateUser(string username, string password, int recruit)
        {
            if (validationServices.CheckIfUserNameExists(username, password, recruit))
            {
                MembershipManagementModels.Member user = new MembershipManagementModels.Member
                {
                    username = username,
                    password = password,
                    recruit = recruit
                };

                bool addUserResult = userData.AddUser(user) > 0;
                if (addUserResult)
                {
                    Console.WriteLine($"User '{username}' added successfully.");
                }
                else
                {
                    Console.WriteLine($"Failed to add user '{username}'.");
                }

                return addUserResult;
            }
            else
            {
                Console.WriteLine($"Validation failed for username '{username}', password '{password}', recruit '{recruit}'.");
                return false;
            }
        }




        public bool UpdateUser(Member user)
        {
            bool result = false;

            if (validationServices.CheckIfUserNameExists(user.username, user.password, user.recruit))
            {
                result = userData.UpdateUser(user) > 0;
            }

            return result;
        }

        public bool UpdateUser(string username, string password, int recruit)
        {
            MembershipManagementModels.Member user = new MembershipManagementModels.Member
            {
                username = username,
                password = password,
                recruit = recruit
            };

            bool result = validationServices.CheckIfUserNameExists(username, password, recruit);
            if (result)
            {
                result = userData.UpdateUser(user) > 0;
            }

            return result;
        }


        public bool DeleteUser(Member user)
        {

            Member existingUser = userData.GetUser(user.username, user.password);

            if (existingUser != null)
            {
                return userData.DeleteUser(existingUser.username) > 0;
            }
            else
            {
                Console.WriteLine($"User '{user.username}' not found.");
                return false;
            }
        }
        public bool DeleteUser(string username, string password)
        {
            
            Member existingUser = userData.GetUser(username, password);

            if (existingUser != null)
            {
                return userData.DeleteUser(existingUser.username) > 0;
            }
            else
            {
                Console.WriteLine($"User '{username}' not found.");
                return false;
            }
        }

    }
}

