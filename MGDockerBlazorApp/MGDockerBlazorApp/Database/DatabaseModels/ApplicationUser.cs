using Microsoft.AspNetCore.Identity;

namespace MGDockerBlazorApp.Database.DatabaseModels
{
    public class ApplicationUser : IdentityUser
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
}
