using System;
using System.Collections.Generic;
using YoyoTournaments.Authentication;

namespace YoyoTournaments.Models
{
    public class Player
    {
        private ICollection<Division> divisions;

        public Player()
        {
            this.divisions = new HashSet<Division>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int CountryId { get; set; }

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

        public Guid UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
