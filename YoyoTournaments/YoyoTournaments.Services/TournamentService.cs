using Bytes2you.Validation;
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
    public class TournamentService : ITournamentService
    {
        private readonly IYoyoTournamentsDbContext dbContext;
        private readonly IDivisionTypeService divisionTypeService;

        public TournamentService(IYoyoTournamentsDbContext dbContext, IDivisionTypeService divisionTypeService)
        {
            Guard.WhenArgument(dbContext, nameof(dbContext)).IsNull().Throw();
            Guard.WhenArgument(divisionTypeService, nameof(divisionTypeService)).IsNull().Throw();

            this.dbContext = dbContext;
            this.divisionTypeService = divisionTypeService;
        }

        public Tournament GetTournamentById(Guid id)
        {
            Tournament result = null;

            if (id != null)
            {
                result = this.dbContext.Tournaments
                 .Find(id);
            }

            return result;
        }

        public void CreateTournament(string name, string place, DateTime startDate, DateTime endDate, Guid countryId)
        {
            //SHOULD validate the input
            var tournament = new Tournament
            {
                Name = name,
                Place = place,
                StartDate = startDate,
                EndDate = endDate,
                CountryId = countryId
            };

            var divisionTypes = this.divisionTypeService.GetAllDivisionTypes().ToList();

            foreach (var dt in divisionTypes)
            {
                Division division = new Division
                {
                    DivisionTypeId = dt.Id,
                    Tournament = tournament
                };

                this.dbContext.Divisions.Add(division);
            }

            dbContext.SaveChanges();
        }
    }
}
