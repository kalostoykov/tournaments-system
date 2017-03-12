using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoyoTournaments.Models.Contracts
{
    public interface IPlayer
    {
        int Id { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }

        int CountryId { get; set; }

        Country Country { get; set; }

        ICollection<ITournament> Tournaments { get; set; }
    }
}
