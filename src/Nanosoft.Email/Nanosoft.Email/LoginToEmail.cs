using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/*
        This simple library program will let you send email messages easily.

        1st Keep the credentials;
        2nd Validate the addresses;
        3rd Choose SMTP;
        4th Send message;
        ...
        Ah! Something else, lets add CC or Bcc too ;)
*/

namespace Nanosoft.Email
{  
    public class LoginToEmail
    {
        private static string _email, _password, _smtp;
        private static UInt16? _Port;
        private List<string> emailsAddressCC = new List<string> { };
        private List<string> emailsAddressBCC = new List<string> { };



        public LoginToEmail(string email, string password, string? SmtpHost = null, UInt16? Port = null)
        {
            _Port = Port is null ? 587 : Port;
            _email = (IsEmailAddressValid(email))? email
                : throw new AccessViolationException(nameof(email));
            _password = (!(password == null))?password
                : throw new AccessViolationException(nameof(password));
            if((!_email.ToLower().Contains("gmail")     &
                !_email.ToLower().Contains("yahoo")     &
                !_email.ToLower().Contains("live")      &
                !_email.ToLower().Contains("hotmail"))  &
                SmtpHost == null
                )
                throw new ArgumentException(nameof(SmtpHost), "The 'Host SMTP' cannot be null!" +
                    "The algorithm cannot recognize your SMTP host from the corresponding email.");

            _smtp = SmtpHost is null ? findSmtp(_email) : SmtpHost;
        }


        public void AddCC(params string[] email)
        {
            foreach (var __email in email)
            {
                if (IsEmailAddressValid(__email))
                    emailsAddressCC.Add(__email);
            }
        }

        public void AddBCC(params string[] email)
        {
            foreach (var __email in email)
            {
                if (IsEmailAddressValid(__email))
                    emailsAddressBCC.Add(__email);
            }
        }


        private bool IsEmailAddressValid(string _)
        {
            string _EmailAddressPattern = @"^(([^@\s!][a-zA-Z0-9\.\-]+[^@\s+!])(@)[a-zA-Z0-9\.\-]+(\.)([^@\s+!]\w+)([^@\s+!]\w+)?([^@\s+!]\w+)?([^@\s+!]\w+)?\b)$";
            Regex DefEmailAddressRegExp = new Regex(_EmailAddressPattern);
            return DefEmailAddressRegExp.IsMatch(_) ? true : false;
        }



        private string findSmtp(string email_smtp)
        {
            var aux = email_smtp;
            email_smtp =
                (aux.ToLower()
                .Contains("gmail") ?
                email_smtp = "smtp.gmail.com" : email_smtp = null);
            email_smtp ??=
                (aux.ToLower()
                .Contains("yahoo") ?
                email_smtp = "smtp.mail.yahoo.com" : email_smtp = null);
            email_smtp ??=
                (aux.ToLower()
                .Contains("live") ?
                email_smtp = "smtp.live.com" : email_smtp = null);
            email_smtp ??=
                (aux.ToLower()
                .Contains("hotmail") ?
                email_smtp = "smtp.live.com" : email_smtp = "smtp.gmail.com");

            return email_smtp;
        }



        public void SendNewEmail(string _to, string _Subject, string _Body, bool IsBodyHTML = true)
        {
            SmtpClient smtpClient = new SmtpClient(_smtp)
            {
                Port = (int)(_Port),
                Credentials = new NetworkCredential(_email, _password),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_email),
                Subject = _Subject,
                Body = _Body,
                IsBodyHtml = IsBodyHTML,
            };

            mailMessage.To.Add(_to);

            foreach (var CCMail in emailsAddressCC)
            {
                mailMessage.CC.Add(CCMail);
            }

            foreach (var BCCMail in emailsAddressBCC)
            {
                mailMessage.Bcc.Add(BCCMail);
            }

            smtpClient.Send(mailMessage);
        }


    }
}
