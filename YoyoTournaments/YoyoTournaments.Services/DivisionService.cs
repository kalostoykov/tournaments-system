using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoyoTournaments.Data.Contracts;
using YoyoTournaments.Models;
using YoyoTournaments.Services.Contracts;

namespace YoyoTournaments.Services
{
    public class DivisionService : IDivisionService
    {
        private readonly IYoyoTournamentsDbContext dbContext;
        private readonly IDivisionTypeService divisionTypeService;

        public DivisionService(IYoyoTournamentsDbContext dbContext, IDivisionTypeService divisionTypeService)
        {
            this.dbContext = dbContext;
            this.divisionTypeService = divisionTypeService;
        }

        public int CreateDivisionsForTournament(Guid tournamentId)
        {
            Tournament foundTournament = this.dbContext.Tournaments.Find(tournamentId);

            if (foundTournament == null)
            {
                return 0;
            }

            var divisionTypes = this.divisionTypeService.GetAllDivisionTypes().ToList();

            foreach (var dt in divisionTypes)
            {
                Division division = new Division
                {
                    DivisionTypeId = dt.Id,
                    TournamentId = tournamentId
                };

                this.dbContext.Divisions.Add(division);
            }

            return this.dbContext.SaveChanges();
        }
    }
}
