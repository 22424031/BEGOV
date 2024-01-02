using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ward.Application.Contracts.Mail
{
    public interface ISendMail
    {
        Task<bool> SendMailTo(string toMail, string content);
    }
}
