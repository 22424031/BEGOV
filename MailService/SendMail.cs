using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ward.Application.Contracts.Mail;

namespace MailService
{
    public class SendMail : BaseEmailAzure, ISendMail 
    {
        public SendMail(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<bool> SendMailTo(string toMail, string content)
        {
            return await SendMail(toMail, content);
        }
    }
}
