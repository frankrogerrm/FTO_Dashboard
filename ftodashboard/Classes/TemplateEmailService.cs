using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using ftodashboard.Models;
using System.Collections.Generic;
using System.Net.Mail;

namespace ftodashboard.Classes
{
    public class TemplateEmailService : EmailService
    {
        public TemplateEmailService(IConfiguration config, IWebHostEnvironment env, NavigationManager nav) : base(config, env, nav) { }


    }
}
