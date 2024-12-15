using System.Net.Mail;
using System.Net;

namespace Api.Services
{
    public class EmailService
    {
        private readonly string smtpServer;
        private readonly int smtpPort;
        private readonly string smtpUser;
        private readonly string smtpPass;

        public EmailService()
        {
            this.smtpServer = "smtp.gmail.com";
            this.smtpPort = 587;
            this.smtpUser = "cofautoapp@gmail.com";
            this.smtpPass = "hhjb sreb hlqi foja";
        }

        public async Task<bool> SendEmailAsync(string toEmail, string subject, string body)
        {
            try
            {

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(smtpUser);
                    mail.To.Add(toEmail);
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient(smtpServer, smtpPort))
                    {
                        smtp.Credentials = new NetworkCredential(smtpUser, smtpPass);
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                    return true;
                }
                //using (var smtpClient = new SmtpClient(smtpServer, smtpPort))
                //{
                //    smtpClient.Credentials = new NetworkCredential(smtpUser, smtpPass);
                //    smtpClient.EnableSsl = true;

                //    var mailMessage = new MailMessage
                //    {
                //        From = new MailAddress(smtpUser),
                //        Subject = subject,
                //        Body = body,
                //        IsBodyHtml = true
                //    };

                //    mailMessage.To.Add(toEmail);

                //    await smtpClient.SendMailAsync(mailMessage);
                //    return true;
                //}
            }
            catch (Exception ex)
            {
                // Log ou trate o erro
                Console.WriteLine($"Erro ao enviar e-mail: {ex.Message}");
                return false;
            }
        }
    }
}
