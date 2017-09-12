using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using DDDExample.Domain.Entities;
using DDDExample.Domain.Interfaces.Services;

namespace DDDExample.Domain.Services
{
    public class EmailService : IEmailService
    {
        #region Fields

        private readonly string _user = ConfigurationManager.AppSettings["SMTPUser"];
        private readonly string _password = ConfigurationManager.AppSettings["SMTPPassword"];
        private readonly string _smtpServer = ConfigurationManager.AppSettings["SMTPServer"];
        private readonly int _smtpPort = Convert.ToInt32(ConfigurationManager.AppSettings["SMTPPort"]);

        #endregion

        #region Constructors

        #endregion

        #region Methods

        public void SendEmail(Email entity)
        {
            var mail = new MailMessage();

            var smtp = new SmtpClient(_smtpServer, _smtpPort)
            {
                Credentials = new NetworkCredential(_user, _password)
            };

            if (entity.ItemAttach != null && entity.ItemAttach.Any())
            {
                Stream fileAtt = new MemoryStream(entity.ItemAttach, true);
                var att = new Attachment(fileAtt, entity.AttachmentName)
                {
                    TransferEncoding = TransferEncoding.Base64
                };

                mail.Attachments.Add(att);
            }

            mail.From = new MailAddress(entity.From);

            foreach (var emailTo in entity.To)
                mail.To.Add(emailTo);
            
            if (entity.IsBcc(entity))
                foreach (var emailCc in entity.Cc)
                    mail.CC.Add(emailCc);

            if (entity.IsCc(entity))
                foreach (var emailCc in entity.Cc)
                    mail.CC.Add(emailCc);

            mail.Priority = MailPriority.Normal;

            mail.IsBodyHtml = !entity.IsHtml.HasValue || entity.IsHtml.Value;

            mail.Subject = entity.Subject;

            mail.Body = entity.Body;

            mail.SubjectEncoding = Encoding.UTF8;

            mail.BodyEncoding = Encoding.UTF8;

            smtp.Send(mail);
        }

        #endregion
    }
}