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

        public int AddUserToDivision(string  userId, Guid divisionId)
        {
            //guards
            Guard.WhenArgument(userId, nameof(userId)).IsNullOrEmpty().Throw();

            //var division = this.dbContext.Divisions.Find(divisionId);
            var division = this.GetDivisionById(divisionId);

            if (division == null)
            {
                return 0;
            }

            var userToAdd = this.dbContext.Users.Find(userId);

            if (userToAdd == null)
            {
                return 0;
            }

            division.Users.Add(userToAdd);

            return this.dbContext.SaveChanges();
        }
    }
}
