using MembershipManagementData;
using MembershipManagementModels;

namespace MembershipManagementServices
{
    public class MembershipGetServices
    {
        private List<Member> GetAllUsers()
        {
            MemberData userData = new MemberData();

            return userData.GetUsers();

        }

        public List<Member> GetUsersByStatus(int userStatus)
        {
            List<Member> usersByStatus = new List<Member>();

            foreach (var user in GetAllUsers())
            {
                if (user.recruit == userStatus)
                {
                    usersByStatus.Add(user);
                }
            }

            return usersByStatus;
        }

        public Member GetUser(string username, string password)
        {
            Member foundUser = new Member();

            foreach (var user in GetAllUsers())
            {
                if (user.username == username && user.password == password)
                {
                    foundUser = user;
                }
            }

            return foundUser;
        }

        public Member GetUser(string username)
        {
            Member foundUser = new Member();

            foreach (var user in GetAllUsers())
            {
                if (user.username == username)
                {
                    foundUser = user;
                }
            }

            return foundUser;
        }
    }


}
