using Bytes2you.Validation;
using System;
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

        public DivisionTypeService(IYoyoTournamentsDbContext dbContext)
        {
            Guard.WhenArgument(dbContext, "dbContext").IsNull().Throw();

            this.dbContext = dbContext;
        }

        public IEnumerable<DivisionType> GetAllDivisionTypes()
        {
            var result =  this.dbContext.DivisionTypes.ToList();

            return result;
        }

        public DivisionType GetDivisionTypeById(Guid? id)
        {
            DivisionType result = null;

            if (id != null)
            {
                result = this.dbContext.DivisionTypes
                    .Find(id);
            }

            return result;
        }
    }
}
