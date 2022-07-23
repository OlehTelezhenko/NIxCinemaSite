using Microsoft.AspNetCore.Identity;

namespace NixCinemaSite.DAL.IdentityEntities
{
    public class User : IdentityUser
    {
        public int Year { get; set; }
    }
}
