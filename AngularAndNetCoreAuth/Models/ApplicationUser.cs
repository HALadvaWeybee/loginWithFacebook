using Microsoft.AspNetCore.Identity;

namespace AngularAndNetCoreAuth.Models
{
    public class ApplicationUser:IdentityUser
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }

        public string UserName { get; set; }
        public int ExpiryTime { get; set; }

        public string RefreshTokens { get; set; }

        public string UserAgent { get; set; }

    }
}
