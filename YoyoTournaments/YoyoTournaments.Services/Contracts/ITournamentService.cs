using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoyoTournaments.Models;

namespace YoyoTournaments.Services.Contracts
{
    public interface ITournamentService
    {
        IEnumerable<Tournament> GetAllTournamentsWIthPaging(out int count, int page = 1, int pageSize = 10);

        Tournament GetTournamentById(Guid id);

        void CreateTournament(string name, string place, DateTime startDate, DateTime endDate, Guid countryId);
    }
}
