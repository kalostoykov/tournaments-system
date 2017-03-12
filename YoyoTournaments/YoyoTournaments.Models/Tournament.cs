using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoyoTournaments.Models.Contracts;

namespace YoyoTournaments.Models
{
    public class Tournament : ITournament
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public virtual ICollection<IPlayer> OneAPlayers { get; set; }

        public virtual ICollection<IPlayer> TwoAPlayers { get; set; }

        public virtual ICollection<IPlayer> ThreeAPlayers { get; set; }

        public virtual ICollection<IPlayer> FourAPlayers { get; set; }

        public virtual ICollection<IPlayer> FiveAPlayers { get; set; }
    }
}
