using ContactPro.Models;
using MailKit.Security;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options; // For accessing values from user Secrets
using MimeKit;
using MailKit.Net.Smtp;

namespace ContactPro.Services
{
    public class EmailService : IEmailSender
    {
        private readonly MailSettings _mailSettings; // Injecting MailSettings to our service

        // With the IOptions we are telling it to go to the Config file and get the MailSettings
        public EmailService(IOptions<MailSettings>mailSettings)
        {
            _mailSettings = mailSettings.Value; 
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var emailSender = _mailSettings.Email ?? Environment.GetEnvironmentVariable("Email");

            // this gives us the ability to log in to that email account(gmail)
            //var emailSender = _mailSettings.Email; // This is the ability to send email, the gmail account

            // This will allow us to create email messages with MailKit and send them wit MimeKit
            MimeMessage newEmail = new();

            // it stores the email address to Sender, which will send the email later
            newEmail.Sender = MailboxAddress.Parse(emailSender);

            foreach ( var EmailAddress in email.Split(";"))
            {   // after splitting the email addresses we add them to 
                newEmail.To.Add(MailboxAddress.Parse(EmailAddress));

            }

            // it will retrieve the subject and store it in Subject
            newEmail.Subject = subject;

            // The next 2 lines of code is formatting our email message
            BodyBuilder emailBody = new();
            emailBody.HtmlBody = htmlMessage;

            newEmail.Body = emailBody.ToMessageBody();

            // lets get log into our smtmp client
            using SmtpClient smtpClient = new();

            try 
            {
                var host = _mailSettings.Host ?? Environment.GetEnvironmentVariable("Email"); 
                var port = _mailSettings.Port != 0 ? _mailSettings.Port : int.Parse(Environment.GetEnvironmentVariable("Port")!); 
                var password = _mailSettings.Password ?? Environment.GetEnvironmentVariable("Password"); 

                // ecureSocketOptions.StartTls is going to encrypt it end-to-end -- it is the encryption level
                await smtpClient.ConnectAsync(host, port, SecureSocketOptions.StartTls);
                await smtpClient.AuthenticateAsync(emailSender, password);


                await smtpClient.SendAsync(newEmail);
                await smtpClient.DisconnectAsync(true);
            }
            catch(Exception ex)
            {
                var error = ex.Message;
                throw;
            }
            
        }
    }
}
