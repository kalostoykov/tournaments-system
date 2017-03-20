using System.Collections.Generic;
using System.Linq;
using YoyoTournaments.Data;
using YoyoTournaments.Data.Contracts;
using YoyoTournaments.Models;
using YoyoTournaments.Services.Contracts;

namespace YoyoTournaments.Services
{
    public class DivisionTypeService : IDivisionTypeService
    {
        private readonly IYoyoTournamentsDbContext dbContext;

        // Just for testing. After Ninject is ready to go delete this constructor.
        public DivisionTypeService()
        {
            this.dbContext = new YoyoTournamentsDbContext();
        }

        public DivisionTypeService(IYoyoTournamentsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<DivisionType> GetAllDivisions()
        {
            return this.dbContext.DivisionTypes.ToList();
        }
    }
}
