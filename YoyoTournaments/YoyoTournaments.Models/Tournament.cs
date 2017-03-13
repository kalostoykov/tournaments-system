using System;
using System.Collections.Generic;

namespace YoyoTournaments.Models
{
    public class Tournament
    {
        private ICollection<Division> divisionsInTournament;

        public Tournament()
        {
            this.divisionsInTournament = new HashSet<Division>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public string Place { get; set; }

        public virtual ICollection<Division> DivisionsInTournament
        {
            get
            {
                return this.divisionsInTournament;
            }

            set
            {
                this.divisionsInTournament = value;
            }
        }

    }
}
