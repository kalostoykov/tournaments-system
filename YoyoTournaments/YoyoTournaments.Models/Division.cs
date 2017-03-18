using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoyoTournaments.Models
{
    public class Division
    {
        private ICollection<ApplicationUser> users;

        public Division()
        {
            this.users = new HashSet<ApplicationUser>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public int DivisionTypeId { get; set; }

        public virtual DivisionType DivisionType { get; set; }

        public virtual ICollection<ApplicationUser> Users
        {
            get
            {
                return this.users;
            }

            set
            {
                this.users = value;
            }
        }

        public Guid TournamentId { get; set; }

        public virtual Tournament Tournament { get; set; }
    }
}
