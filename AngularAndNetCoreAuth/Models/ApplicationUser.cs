using AngularAndNetCoreAuth.Data;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AngularAndNetCoreAuth.Models
{
    public class ApplicationUser : IdentityUser
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string? UserAgent { get; set; }

        public string? FirstName { get; set; }

        public AspNetUserProfile AspNetUserProfile { get; set; }

        public List<AspNetRefreshToken> RefreshTokens { get; set; }

    }

}

