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
            var AdminUser = new LoginToEmail("test@name.com","password"); // Your credentials

            AdminUser.AddCC("test1@name.com"); // Add a CC

            AdminUser.AddBCC("test2@name.com");// Add a BCC

            AdminUser.SendNewEmail(
                // To
                "test3@name.com",

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
