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

        public IEnumerable<Tournament> GetAllTournamentsWIthPaging(out int count, int page = 1, int pageSize = 10)
        {
            if (page < 1)
            {
                page = 1;
            }

            if (pageSize < 1)
            {
                pageSize = 1;
            }

            var result = this.dbContext.Tournaments
                .OrderBy(x => x.StartDate)
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .ToList();

            count = this.dbContext.Tournaments.Count();

            return result;
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
            // TODO: Refactor this method if I can

            Guard.WhenArgument(name, nameof(name)).IsNullOrEmpty().Throw();
            Guard.WhenArgument(place, nameof(place)).IsNullOrEmpty().Throw();
            Guard.WhenArgument(startDate, nameof(startDate)).IsLessThan(DateTime.Now).Throw();
            Guard.WhenArgument(endDate, nameof(endDate)).IsLessThan(startDate).Throw();

            var divisionTypes = this.divisionTypeService.GetAllDivisionTypes().ToList();

            if (divisionTypes.Count == 0)
            {
                throw new NullReferenceException("No division types were found!");
            }

            var tournament = new Tournament
            {
                Name = name,
                Place = place,
                StartDate = startDate,
                EndDate = endDate,
                CountryId = countryId
            };

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
