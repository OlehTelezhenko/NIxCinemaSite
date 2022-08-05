using Microsoft.AspNetCore.Identity;

namespace NixCinemaSite.DAL.Entities.Identity
{
    public class User : IdentityUser
    {
        public DateTime DateOfBirth { get; set; }
    }
}
