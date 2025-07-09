using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Net.Mail;


namespace ftodashboard.Classes
{
    public class EmailService
    {
        protected IConfiguration Config;
        protected string From;
        protected int Port;
        protected string Host;
        protected string Username;
        protected string Password;

        protected IWebHostEnvironment Env;
        protected NavigationManager Nav;
        public EmailService(IConfiguration mailConfig, IWebHostEnvironment env, NavigationManager nav)
        {
            Nav = nav;
            Env = env;

            IConfiguration settings;

            Config = mailConfig.GetSection("Email");
            if (Env.IsProduction())
            {
                settings = Config.GetSection("Settings");
            }
            else
            {
                settings = Config.GetSection("DevSettings");
            }
            From = settings.GetSection("From").Value;
            Port = int.Parse(settings.GetSection("Port").Value);
            Host = settings.GetSection("Host").Value;
            Username = settings.GetSection("Username").Value;
            Password = settings.GetSection("Password").Value;
        }

        public void SendEmail(string ToEmail, string Subject, string emailTemplate, object[] items)
        {
            MailMessage msg = new();
            msg.To.Add(new MailAddress(ToEmail, "The Recipient"));
            msg.From = new MailAddress(From, "The Sender");
            msg.Subject = "Test Email from Azure Web App using Office365";
            msg.Body = FormatTemplate(LoadTemplate(emailTemplate), items);
            msg.IsBodyHtml = true;
            SmtpClient client = new();
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(Username, Password);
            client.Port = Port;
            client.Host = Host;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;

            client.Send(msg);

        }
        protected string LoadTemplate(string filePath)
        {
            var pathToFile = Env.ContentRootPath
                            + Path.DirectorySeparatorChar.ToString()
                            + "wwwroot"
                            + Path.DirectorySeparatorChar.ToString()
                            + "Templates"
                            + Path.DirectorySeparatorChar.ToString()
                            + "Email"
                            + Path.DirectorySeparatorChar.ToString()
                            + filePath
                            + ".html";

            return File.ReadAllText(pathToFile);
        }

        protected string FormatTemplate(string template, object[] items)
        {
            // example items = new object[] { name, email, url, time }
            return string.Format(template, items);
        }
    }
}
