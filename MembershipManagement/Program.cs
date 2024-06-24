using MembershipManagementData;
using MembershipManagementModels;
using System;
using System.Collections.Generic;

namespace MemebershipManagement
{
    public class Program
    {
        static void Main(string[] args)
        {
            SqlDbData dbData = new SqlDbData();
            dbData.AddUser("joyceguigayoma", "joyy123");
            GetUsers(dbData);
        }
        public static void GetUsers(SqlDbData dbData)
        {
            List<Member> usersFromDB = dbData.GetUsers();
            foreach (var item in usersFromDB)
            {
                Console.WriteLine(item.username);
                Console.WriteLine(item.password);


            }
        }

    }
}