using MembershipManagementModels;

namespace MembershipEmailTools
{
    public class MembershipEmailServices
    {
        private EmailService emailService;

        public MembershipEmailServices()
        {
            emailService = new EmailService();
        }

        public void RegistrationEmail(Member newMember)
        {
            string subject = "Welcome to UnityMembers!";
            string body = $"<h1>Hi {newMember.username},</h1>" +
                          $"<p>Thank you for registering with UnityMembers. You have {newMember.recruit} recruits.</p>";

            emailService.SendEmail(newMember.username, "user@example.com", subject, body);
        }

        public void LoginEmail(Member member)
        {
            string subject = "Login Notification";
            string body = $"<h1>Hi {member.username},</h1>" +
                          "<p>You have successfully logged in to your account.</p>";

            emailService.SendEmail(member.username, "user@example.com", subject, body);
        }

    }
}

