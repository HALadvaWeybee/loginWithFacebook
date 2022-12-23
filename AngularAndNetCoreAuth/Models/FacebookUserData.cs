using System.ComponentModel.DataAnnotations.Schema;

namespace AngularAndNetCoreAuth.Models
{
    public class FacebookUserData
    {
        public string id { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
    }
}
