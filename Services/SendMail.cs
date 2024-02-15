using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace TS.Services
{
    public class SendMail : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailbox = MailboxAddress.Parse("info@smsoftconsulting.com");
            mimeMessage.From.Add(mailbox);

            MailboxAddress to = new MailboxAddress(htmlMessage, email);
            mimeMessage.To.Add(to);

            mimeMessage.Subject = subject;

            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = email + htmlMessage;

            mimeMessage.Body = bodyBuilder.ToMessageBody();

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 465, true);
            smtpClient.Authenticate("info@smsoftconsulting.com", "smsoftconsulting@123");

            await smtpClient.SendAsync(mimeMessage);
            smtpClient.Disconnect(true);
            smtpClient.Dispose();
        }
    }
}
