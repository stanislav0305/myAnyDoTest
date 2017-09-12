using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AnyDo.WebAPI.Models;
using AnyDo.Data.Models;
using AnyDo.Data.Repositories;
using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace AnyDo.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/mail")]
    public class MailController : Controller
    {
        IConfiguration configurationService;
        IMailSender mailSender;
        
        public MailController(IConfiguration configurationService, 
            IMailSender mailSender)
        {
            this.configurationService = configurationService;
            this.mailSender = mailSender;
        }

        [HttpPost]
        public void Post([FromBody]InvintationMailCreateApiModel model)
        {
            if (ModelState.IsValid)
            {
                var dbModel = Mapper.Map<InvintationMailCreateApiModel, InvintationMail>(model);
                dbModel.Smtp = GetSmtpOptions();
                dbModel.From = GetMailFromOptions();

                mailSender.SendInvintation(dbModel);
            }
        }

        private SmtpOptions GetSmtpOptions()
        {
            var smtpOptions = new SmtpOptions();
            smtpOptions.Url = configurationService.GetSection("MailSenderConfigurations").GetSection("Smtp").GetValue<string>("Url");
            smtpOptions.Port = configurationService.GetSection("MailSenderConfigurations").GetSection("Smtp").GetValue<int>("Port");

            return smtpOptions;
        }

        private MailFromOptions GetMailFromOptions()
        {
            var fromOptions = new MailFromOptions();
            fromOptions.MailAdress = configurationService.GetSection("MailSenderConfigurations").GetSection("MailFrom").GetValue<string>("Mail");
            fromOptions.Name = configurationService.GetSection("MailSenderConfigurations").GetSection("MailFrom").GetValue<string>("Name");
            fromOptions.Password = configurationService.GetSection("MailSenderConfigurations").GetSection("MailFrom").GetValue<string>("Password");

            return fromOptions;
        }
    }
}