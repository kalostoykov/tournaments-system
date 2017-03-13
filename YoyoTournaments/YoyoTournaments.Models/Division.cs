using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoyoTournaments.Models
{
    public class Division
    {
        private ICollection<Player> players;

        public Division()
        {
            this.players = new HashSet<Player>();
        }

        public int Id { get; set; }

        public int DivisionTypeId { get; set; }

        public virtual DivisionType DivisionType { get; set; }

        public virtual ICollection<Player> Players
        {
            get
            {
                return this.players;
            }
        }

        public int TournamentId { get; set; }

        public virtual Tournament Tournament { get; set; }
    }
}
