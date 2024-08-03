using Microsoft.AspNetCore.Identity;

namespace WebApplication9.Models

{
    public class ApplicationUser:IdentityUser
    {
        public string Email { get; set; }
    }
}
