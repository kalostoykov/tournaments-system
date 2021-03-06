﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using YoyoTournaments.Common;

namespace YoyoTournaments.Models
{
    public class ApplicationUser : IdentityUser
    {
        private ICollection<Division> divisions;

        public ApplicationUser()
        {
            this.divisions = new HashSet<Division>();
        }

        [MinLength(Validation.MinNameLength)]
        [MaxLength(Validation.MaxNameLength)]
        public string FirstName { get; set; }

        [MinLength(Validation.MinNameLength)]
        [MaxLength(Validation.MaxNameLength)]
        public string LastName { get; set; }

        //TODO: remove the ? after the registration page is complete
        public Guid? CountryId { get; set; }

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
