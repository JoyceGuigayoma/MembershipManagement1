using MembershipManagementModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipManagementData
{
    public class MemberData
    {
        private SqlDbData sqlData;

        public MemberData()
        {
            sqlData = new SqlDbData();
        }

        public List<Member> GetUsers(string username, string password, int recruit)
        {
            try
            {
                return sqlData.GetUsers();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching users: " + ex.Message);
                throw;
            }
        }

        public Member GetUser(string username, string password)
        {

            {
                return sqlData.GetUser(username, password);
            }
        }

        public List<Member> GetUsersByRecruit(int recruitStatus)
        {
            try
            {
                return sqlData.GetUsersByRecruit(recruitStatus);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching users by recruit status: " + ex.Message);
                throw;
            }
        }

        public int AddUser(Member user)
        {
            try
            {
                return sqlData.AddUser(user.username, user.password, user.recruit);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding user: " + ex.Message);
                throw;
            }
        }

        public int UpdateUser(Member user)
        {
            try
            {
                return sqlData.UpdateUser(user.username, user.password, user.recruit);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating user: " + ex.Message);
                throw;
            }
        }

        public int DeleteUser(string username)
        {
            try
            {
                return sqlData.DeleteUser(username);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting user: " + ex.Message);
                throw;
            }
        }
    }
}
