using MembershipManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipManagementData
{
    public class MemberData
    {
        List<Member> users;
        SqlDbData sqlData;
        public MemberData()
        {
            users = new List<Member>();
            sqlData = new SqlDbData();

            //UserFactory _userFactory = new UserFactory();
            //users = _userFactory.GetDummyUsers();
        }

        public List<Member> GetUsers()
        {
            users = sqlData.GetUsers();
            return users;
        }

        public int AddUser(Member user)
        {
            return sqlData.AddUser(user.username, user.password);
        }

        public int UpdateUser(Member user)
        {
            return sqlData.UpdateUser(user.username, user.password);
        }

        public int DeleteUser(Member user)
        {
            return sqlData.DeleteUser(user.username);
        }
    }
}
