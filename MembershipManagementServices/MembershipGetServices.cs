using MembershipManagementData;
using MembershipManagementModels;


namespace MembershipManagementServices
{
    public class MembershipGetServices
    {
        private MemberData memberData;

        public MembershipGetServices()
        {
            memberData = new MemberData();
        }
        public List<Member> GetUsersByRecruit(int recruitStatus)
        {
            try
            {
                return memberData.GetUsersByRecruit(recruitStatus);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching users by recruit status: " + ex.Message);
                throw;
            }
        }
        public Member GetUser(string username, string password, int recruit)
        {
            try
            {

                return memberData.GetUser(username, password);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching user: " + ex.Message);
                throw;
            }
        }

        public Member AuthenticateUser(string username, string password)
        {

            Member user = memberData.GetUser(username, password);



            return user;
        }

    }
}
