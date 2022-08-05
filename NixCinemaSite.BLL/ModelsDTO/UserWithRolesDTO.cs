using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace NixCinemaSite.BLL.ModelsDTO
{
    public class UserWithRolesDTO : UserDTO
    {
        [Display(Name = "Роль(і)")]
        public List<string> UserRoles { get; set; }
        public List<IdentityRole> AllRoles { get; set; }

        public UserWithRolesDTO()
        {
            AllRoles = new List<IdentityRole>();
            UserRoles = new List<string>();
        }

        /*
        /// Gets or sets the user name for this user
        public virtual string UserName { get; set; }

        /// Gets or sets the normalized user name for this user.
        public virtual string NormalizedUserName { get; set; }

        /// Gets or sets the email address for this user.
        public virtual string Email { get; set; }

        /// Gets or sets the normalized email address for this user.
        public virtual string NormalizedEmail { get; set; }

        /// Gets or sets a flag indicating if a user has confirmed their email address.
        public virtual bool EmailConfirmed { get; set; }

        /// Gets or sets a salted and hashed representation of the password for this user.
        public virtual string PasswordHash { get; set; }

        /// A random value that must change whenever a users credentials change (password changed, login removed)
        public virtual string SecurityStamp { get; set; }

        /// A random value that must change whenever a user is persisted to the store
        public virtual string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();

        /// Gets or sets a telephone number for the user.
        public virtual string PhoneNumber { get; set; }

        /// Gets or sets a flag indicating if a user has confirmed their telephone address.
        /// <value>True if the telephone number has been confirmed, otherwise false.</value>
        public virtual bool PhoneNumberConfirmed { get; set; }

        /// Gets or sets a flag indicating if two factor authentication is enabled for this user.
        /// <value>True if 2fa is enabled, otherwise false.</value>
        public virtual bool TwoFactorEnabled { get; set; }

        /// Gets or sets the date and time, in UTC, when any user lockout ends.
        /// A value in the past means the user is not locked out.
        public virtual DateTimeOffset? LockoutEnd { get; set; }

        /// Gets or sets a flag indicating if the user could be locked out.
        /// <value>True if the user could be locked out, otherwise false.</value>
        public virtual bool LockoutEnabled { get; set; }

        /// Gets or sets the number of failed login attempts for the current user.
        public virtual int AccessFailedCount { get; set; }

        */
    }
}
