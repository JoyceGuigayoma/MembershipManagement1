using MailKit.Net.Smtp;
using MimeKit;
using System;


namespace MembershipEmailTools
{
    public class EmailService
    {
        public void SendEmail(string recipientName, string recipientEmail, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Membership Management", "do-not-reply@membership.com"));
            message.To.Add(new MailboxAddress(recipientName, recipientEmail));
            message.Subject = subject;

            message.Body = new TextPart("html")
            {
                Text = body
            };

            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect("sandbox.smtp.mailtrap.io", 2525, MailKit.Security.SecureSocketOptions.StartTls);
                    client.Authenticate("dbd961e0e17581", "90e12a31bc57e3");
                    client.Send(message);
                    Console.WriteLine("Email sent successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending email: {ex.Message}");
                }
                finally
                {
                    client.Disconnect(true);
                }
            }
        }
    }
}
