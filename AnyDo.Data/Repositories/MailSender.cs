using AnyDo.Data.Models;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnyDo.Data.Repositories
{
    public class MailSender : IMailSender
    {
        public void SendInvintation(InvintationMail model)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(model.From.Name, model.From.MailAdress));
                message.To.Add(new MailboxAddress("", model.MailTo));
                message.Subject = "Invintation";

                message.Body = new TextPart("plain")
                {
                    Text = model.Message
                };

                using (var client = new SmtpClient())
                {
                    client.Connect(model.Smtp.Url, model.Smtp.Port);

                    // Note: since we don't have an OAuth2 token, disable
                    // the XOAUTH2 authentication mechanism.
                    client.AuthenticationMechanisms.Remove("XOAUTH2");

                    client.Authenticate(model.From.MailAdress, model.From.Password);
                    client.Send(message);
                    client.Disconnect(true);
                }
            }
            catch(Exception e)
            {
                throw new Exception("Mail not sended!", e);
            }
        }
    }

    public interface IMailSender
    {
        void SendInvintation(InvintationMail model);
    }
}
