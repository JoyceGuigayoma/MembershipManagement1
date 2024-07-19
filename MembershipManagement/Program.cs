using MembershipManagementData;
using MembershipManagementModels;
using System;
using System.Collections.Generic;
using System.Xml.Linq;


namespace MembershipManagement
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to UnityMembers Organization!");
            Console.WriteLine("_______________________________________________________________________________________");
            Console.WriteLine("This organization helps you make new friends. To join, you can create an account by choosing register an account.");
            Console.WriteLine("_______________________________________________________________________________________");

            bool isLoggedIn = false;
            Member loggedInUser = null;

            while (!isLoggedIn)
            {
                Console.WriteLine("Choose a number: ");
                Console.WriteLine("1. Log in");
                Console.WriteLine("2. Reister an account");
                string choice = Console.ReadLine();

                if (choice == "1")
                {

                    bool loginSuccess = Login(out loggedInUser);
                    isLoggedIn = loginSuccess;

                }
                else if (choice == "2")
                {

                    Register();
                    isLoggedIn = true;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                }
                if (isLoggedIn && loggedInUser != null)
                {
                    Console.WriteLine("_______________________________________________________________________________________");
                    Console.WriteLine("User Information:");
                    Console.WriteLine($"Username: {loggedInUser.username}");
                    Console.WriteLine($"Recruits: {loggedInUser.recruit}");


                    List<Member> allUsers = GetMember();
                    Console.WriteLine("\nAll Users:");
                    foreach (var user in allUsers)
                    {
                        Console.WriteLine($"Username: {user.username}, Recruits: {user.recruit}");
                    }
                }
                else
                {
                    Console.WriteLine("_______________________________________________________________________________________");
                }
            }

        }

        public static List<Member> GetMember()
        {
            List<Member> allUsers;
            using (SqlDbData dbData = new SqlDbData())
            {
                allUsers = dbData.GetMember();
            }
            return allUsers;
        }



        public static bool Login(out Member loggedInUser)
        {
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();


            using (SqlDbData dbData = new SqlDbData())
            {
                loggedInUser = dbData.GetUser(username, password);
                if (loggedInUser != null)
                {
                    Console.WriteLine($"Welcome back, {loggedInUser.username}!");
                    return true;
                }
                else
                {
                    Console.WriteLine("Invalid username or password. Please try again.");
                    return false;
                }
            }
        }

        public static void Register()
        {
            Console.Write("Enter your username: ");
            string username = Console.ReadLine();
            Console.Write("Enter your password: ");
            string password = Console.ReadLine();
            Console.Write("Enter number of recruits: ");
            int recruits = int.Parse(Console.ReadLine());


            Member newMember = new Member
            {
                username = username,
                password = password,
                recruit = recruits
            };


            SqlDbData dbData = new SqlDbData();


            int success = dbData.AddUser(newMember.username, newMember.password, newMember.recruit);

            if (success > 0)
            {
                Console.WriteLine($"Account created for {username} with {recruits} recruits!");
            }
            else
            {
                Console.WriteLine("Failed to create account. Please try again.");
            }
        }


    }
}
