using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoyoTournaments.Models.Contracts
{
    public interface ITournament
    {
        int Id { get; set; }

        string Name { get; set; }

        DateTime StartDate { get; set; }

        DateTime EndDate { get; set; }

        ICollection<IPlayer> OneAPlayers { get; set; }

        ICollection<IPlayer> TwoAPlayers { get; set; }

        ICollection<IPlayer> ThreeAPlayers { get; set; }

        ICollection<IPlayer> FourAPlayers { get; set; }

        ICollection<IPlayer> FiveAPlayers { get; set; }
    }
}
