using MembershipManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipManagementData
{
    public class MemberFactory
    {
        private List<Member> dummyUsers = new List<Member>();

        public List<Member> GetDummyUsers()
        {
            dummyUsers.Add(CreateDummyUser("joys", "joyjoy", "joy@pup.com"));
            dummyUsers.Add(CreateDummyUser("Test123!", "Test", "Test@pup.com"));
            dummyUsers.Add(CreateDummyUser("Hello123!", "Hello", "Hello@pup.com"));
            dummyUsers.Add(CreateDummyUser("Bye123!", "Bye", "Bye@pup.com"));

            return dummyUsers;
        }

        private Member CreateDummyUser(string password, string username, string emailaddress)
        {
            Member user = new Member
            {
                username = username,
                password = password,
                profile = new MemberProfile { emailAddress = emailaddress, profileName = username },
                dateUpdated = DateTime.Now,
                dateVerified = DateTime.Now.AddDays(1),
                recruit = 1,
            };

            return user;
        }
    }
}
