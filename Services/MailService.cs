﻿using System;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using PCServ.Helpers;
using PCServ.Models;

namespace PCServ.Services
{
    public interface IMailService
    {
        public bool Send(Mail mail);
    }

    public class MailService : IMailService
    {
        private MailConfigHelper _mailConfigHelper;

        public MailService(IOptions<MailConfigHelper> mailConfigHelper)
        {
            _mailConfigHelper = mailConfigHelper.Value;
        }

        public bool Send(Mail mail)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_mailConfigHelper.FromName, _mailConfigHelper.FromMail));
            message.To.Add(new MailboxAddress(mail.ToName, mail.ToMail));
            message.Subject = mail.Subject;

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = mail.HtmlBody,
                TextBody = mail.Body
            };

            message.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                client.Connect(_mailConfigHelper.SmtpAddr, _mailConfigHelper.SmtpPort);
                client.Authenticate(_mailConfigHelper.Username, _mailConfigHelper.Password);

                bool sent = false;

                try
                {
                    client.Send(message);
                    sent = true;
                }
                catch(Exception ex)
                {

                }
                finally
                {
                    client.Disconnect(true);
                }

                return sent;
            }
        }
    }
}
