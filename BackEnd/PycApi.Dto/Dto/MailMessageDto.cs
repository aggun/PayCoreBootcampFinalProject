using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace PycApi.Dto.Dto
{
    public class MailMessageDto
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public MailMessage GetMailMessage()
        {
            var mailMessage = new MailMessage
            {
                Subject = Subject,
                Body = Body,
                From = new MailAddress(From)
            };
            mailMessage.To.Add(To);
            return mailMessage;
        }
    }
}
