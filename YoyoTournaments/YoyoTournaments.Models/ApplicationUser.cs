using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace YoyoTournaments.Models
{
    public class ApplicationUser : IdentityUser
    {
        private ICollection<Division> divisions;

        public ApplicationUser()
        {
            this.divisions = new HashSet<Division>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Guid CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Division> Divisions
        {
            get
            {
                return this.divisions;
            }

            set
            {
                this.divisions = value;
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
