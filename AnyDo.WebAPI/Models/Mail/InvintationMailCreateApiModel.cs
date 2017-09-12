using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnyDo.WebAPI.Models
{
    public class InvintationMailCreateApiModel
    {
        [EmailAddress]
        public string MailTo { get; set; }
        public string Message { get; set; }
    }
}
