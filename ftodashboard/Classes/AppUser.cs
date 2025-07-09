using Microsoft.AspNetCore.Components.Authorization;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ftodashboard.Models;


namespace ftodashboard.Classes
{
    public class AppUser
    {
        public string Name { get; set; } // full name
        public string Email { get; set; } // email address
        public string LoggedInUser { get; set; } // login
        public Employee Employee { get; set; }
        public List<Claim> myclaim { get; set; }

        public async Task Startup(AuthenticationStateProvider Auth)
        {
            var authState = await Auth.GetAuthenticationStateAsync();
            var user = authState.User;
            if (user.Identity.IsAuthenticated)
            {
                myclaim = user.Identities.First().Claims.ToList();
                Name = myclaim.Find(c => c.Type == "name").Value;
                Email = myclaim.Find(c => c.Type == "preferred_username").Value.ToLower();
                LoggedInUser = Email.Substring(0, Email.IndexOf("@")).ToLower();

            }
        }
    }
}