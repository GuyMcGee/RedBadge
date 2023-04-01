using Microsoft.AspNetCore.Identity;

namespace Redbadge.Data.Entities
{
    public class AppUser:IdentityUser
    {
        public DateTime SignUpDate { get; set; }
    }
}