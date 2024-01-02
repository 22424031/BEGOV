using MailKit;
using MimeKit;
using System.Net.Mail;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using System;

namespace MailService
{
    public abstract class BaseMailClient
    {
        private readonly IConfiguration _configuration;
        public BaseMailClient(IConfiguration configuration)
        {
            _configuration = configuration;
           
        }
        protected virtual async Task<bool> SendMail(string toMail, string content)
        {
            var email = new MimeMessage();
            string url = _configuration["mailserver:url"];
            int port = int.Parse(_configuration["mailserver:port"]);
            email.From.Add(new MailboxAddress("Admin", "trutran1992@gmail.com"));
            email.To.Add(new MailboxAddress("No reply", toMail));
            email.Subject = "Thông Báo trạng thái kết quả";
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = $"<b>{content}</b>"
            };

            using(var smtp = new MailKit.Net.Smtp.SmtpClient())
            {
                smtp.Connect(url, port, false);
                // Note: only needed if the SMTP server requires authentication
               smtp.Authenticate("trutranadsmap@gmail.com", "Karipara");
               await smtp.SendAsync(email);
                smtp.Disconnect(true);
                return true;
            }
            return false;
        }
    }
}
