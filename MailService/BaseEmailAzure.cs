

using Azure;
using Azure.Communication.Email;
using Microsoft.Extensions.Configuration;

namespace MailService
{
    public abstract class BaseEmailAzure
    {
        private readonly IConfiguration _configuration;
        public BaseEmailAzure(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected virtual async Task<bool> SendMail(string toEmail, string content)
        {
     
            string connectionString = _configuration["mailserver:urlemailazure"];

            var emailClient = new EmailClient(connectionString);
            var emailContent = new EmailContent(content)
            {
                PlainText = "Duoc gui tu phong quan lý quản cáo",
                Html = $"<html><h1>{content}</h1></html>"
            };
            var toRecipients = new List<EmailAddress>
            {
                new (toEmail)
            };
            var emailRecipients = new EmailRecipients(toRecipients);
            var emailMSG = new EmailMessage("donotreply@6c24cc40-5453-4465-bd25-914747f4b613.azurecomm.net", emailRecipients, emailContent);
            try
            {
                var emailSendOperation = emailClient.Send(Azure.WaitUntil.Completed, emailMSG);
                Console.WriteLine($"Email Sent. Status = {emailSendOperation.Value.Status}");
                var operationId = emailSendOperation.Id;
                Console.WriteLine($"Email operation id = {operationId}");
                return true;
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine($"Email send operation failed with error code: {ex.ErrorCode}, message: {ex.Message}");
            }
            return false;
        }
    }
}
