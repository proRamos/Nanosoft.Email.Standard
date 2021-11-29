using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

/*
        This simple library program will let you send email messages easily.

        1st Keep the credentials;
        2nd Validate the addresses;
        3rd Choose SMTP;
        4th Send message;
        ...
        Ah! Something else, lets add CC too ;)
*/

namespace Nanosoft.Email
{
    public class LoginToEmail
    {
        protected static string _email, _password, _smtp;
        public List<string> emailsAddressCC = new List<string> { };



        public LoginToEmail(string email, string password)
        {
            _email = email;
            _password = password;
            _smtp = findSmtp(_email);
        }


        public void AddCC(params string[] email)
        {
            foreach(var __email in email)
            {
                IsEmailAddressValid(__email);
                emailsAddressCC.Add(__email);
            }
        }



        public void IsEmailAddressValid(string email_smtp)
        {
            if (!email_smtp.ToLower().Contains("@"))
                throw new ArgumentException(nameof(email_smtp),
                    "[ERROR: NOT VALID EMAIL!] " +
                    "Missing '@'.");

            if (!email_smtp.ToLower().Contains("."))
                throw new ArgumentException(nameof(email_smtp),
                    "[ERROR: NOT VALID EMAIL!] " +
                    "Missing '.'.");

            if (email_smtp.ToLower().EndsWith("@"))
                throw new ArgumentException(nameof(email_smtp),
                    "[ERROR: NOT VALID EMAIL!] " +
                    "Ends with '@'");

            if (email_smtp.ToLower().EndsWith("."))
                throw new ArgumentException(nameof(email_smtp),
                    "[ERROR: NOT VALID EMAIL!] " +
                    "Ends with '.'");

            if (email_smtp.ToLower().StartsWith("@"))
                throw new ArgumentException(nameof(email_smtp),
                    "[ERROR: NOT VALID EMAIL!] " +
                    "Starts with '@'");

            if (email_smtp.ToLower().StartsWith("."))
                throw new ArgumentException(nameof(email_smtp),
                    "[ERROR: NOT VALID EMAIL!] " +
                    "Starts with '.'");
        }



        public string findSmtp(string email_smtp)
        {
            IsEmailAddressValid(email_smtp);

            if (email_smtp.ToLower().Contains("gmail"))
                email_smtp = "smtp.gmail.com";

            else if (email_smtp.ToLower().Contains("yahoo"))
                email_smtp = "smtp.mail.yahoo.com";

            else if (email_smtp.ToLower().Contains("hotmail"))
                email_smtp = "smtp.live.com";

            else
                email_smtp = "smtp.gmail.com";

            return email_smtp;
        }



        public void SendNewEmail(string _to, string _Subject, string _Body, bool IsBodyHTML = true)
        {
            SmtpClient smtpClient = new SmtpClient(_smtp)
            {
                Port = 587,
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

            smtpClient.Send(mailMessage);
        }


    }
}
