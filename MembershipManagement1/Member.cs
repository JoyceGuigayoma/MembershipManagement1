namespace MembershipManagementModels
{
    public class Member
    {
        public string username;
        public string password;
        public DateTime dateVerified;
        private DateTime dateCreated = DateTime.Now;
        public DateTime dateUpdated;
        public MemberProfile profile;
        public int recruit;
    }
}