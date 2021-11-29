using System;
using Nanosoft.Email;
/*
    See a simple example of how to use it.
*/
namespace Nanosoft.Email.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var AdminUser = new LoginToEmail("your-name@company-name.com","your-password");
            
            AdminUser.AddCC("cc-one@name.com","cc-two@name.com");
            
            AdminUser.SendNewEmail(
                // To
                "send-to@name.com",

                // Subject
                "Subject",

                // Body
                "<h1>Hello!</h1>" +
                "<h2>Welcome, developer!</h2>" +
                "<p>This is my body's message!</p>",

                // Is your body's message of the html type?
                true
                );
        }
    }
}
