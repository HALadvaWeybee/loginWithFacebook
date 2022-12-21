using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel;

namespace AngularAndNetCoreAuth.Models
{
    //public class ApplicationUser : IdentityUser
    //{
    //    public int Id { get; set; }
    //    public int UserId { get; set; }
    //    public string FirstName { get; set; }
    //    public string Email { get; set; }

    //    public string UserName { get; set; }
    //    public int ExpiryTime { get; set; }

    //    public string RefreshTokens { get; set; }

    //    public string UserAgent { get; set; }

    //}

    public class ApplicationUser : IdentityUser
    {
        public string? UserAgent { get; set; }
        //public string? IpAddress { get; set; }

        public int UserId { get; set; }
        ////public long? CurrencyId { get; set; }

        public int? ExpiryTime { get; set; }
        public string? FirstName { get; set; }
        //public string? MiddleName { get; set; }
        //public string? LastName { get; set; }

        //[DefaultValue(true)]
        //public bool IsLogin { get; set; }

        //public bool IsActive { get; set; } = true;

        //public string? ForgotToken { get; set; }

        public AspNetUserProfile AspNetUserProfile { get; set; }
        public List<AspNetRefreshToken> RefreshTokens { get; set; }
    }


}
