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
    public class DivisionService : IDivisionService
    {
        private readonly IYoyoTournamentsDbContext dbContext;

        public DivisionService(IYoyoTournamentsDbContext dbContext)
        {
            Guard.WhenArgument(dbContext, nameof(dbContext)).IsNull().Throw();

            this.dbContext = dbContext;
        }

        public Division GetDivisionById(Guid id)
        {
            Division result = null;

            if (id != null)
            {
                result = this.dbContext.Divisions
                 .Find(id);
            }

            return result;
        }
    }
}
