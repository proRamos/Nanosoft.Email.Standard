# Nanosoft.Email.Standard
## Nanosoft .Net email sender
![This is an image](https://res.infoq.com/news/2020/11/microsoft-releases-dotnet-5/en/headerimage/croppted-world-of-dotnet-1605034490880.jpg)

### Hey there!
Nanosoft.Email is open source and meets your main .NET needs to make sending email messages as easy as possible. Licensed by MIT.


### How to use? (1.0.0)

.NET and .NET Core come with built-in support for sending email through the System.Net.Mail namespace, the library used. However, you will need an SMTP server for this to work.

To test sending emails via SMTP, you can either use your Gmail account or sign up for a new one. To use Google's SMTP servers, you'll need to enable access to less secure apps on your profile's Security page, the same will need to be done for others:

![Allow it](https://blog.elmah.io/content/images/2020/02/less-secure-app-access-1.png)

As the message says, allowing less secure apps is not recommended. So while it's for our testing purposes, you should consider using something else when running in production. All major email providers offer SMTP-based email sending.For the example below, I'm using a gmail account, you can both use Yahoo! as well as hotmail.

### Example
```csharp

    class Program
    {
        static void Main(string[] args)
        {
            var AdminUser = new LoginToEmail("your-name@company-name.com","your-password");
            
            AdminUser.AddCC("cc-one@name.com","cc-two@name.com", ...); //params string[]
            
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
```
Good! Now you can send email messages even through the console application, congratulations!

## Version 1.1.1
### What's new?

Some internal settings have been changed and you can now send a message to a Bcc.

### Example

```csharp
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

```

[Library from Nuget](https://www.nuget.org/packages/Nanosoft.Email/1.1.1)
 | My [LinkedIn](https://www.linkedin.com/in/proramos/) ;)
