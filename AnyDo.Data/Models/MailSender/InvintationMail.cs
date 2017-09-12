using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnyDo.Data.Models
{
    public class InvintationMail
    {
        public string MailTo { get; set; }
        public string Message { get; set; }
        public MailFromOptions From { get; set; }
        public SmtpOptions Smtp { get; set; }

        public InvintationMail()
        {
            From = new MailFromOptions();
            Smtp = new SmtpOptions();
        }

    }
}
