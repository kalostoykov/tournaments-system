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
    public class CountryService : ICountryService
    {
        private readonly IYoyoTournamentsDbContext dbContext;

        public CountryService(IYoyoTournamentsDbContext dbContext)
        {
            Guard.WhenArgument(dbContext, "dbContext").IsNull().Throw();

            this.dbContext = dbContext;
        }

        public IEnumerable<Country> GetAllCountries()
        {
            var result = this.dbContext.Countries.ToList();

            return result;
        }

        public Country GetCountryById(Guid? id)
        {
            if (id == null)
            {
                return null;
            }

            var result = this.dbContext.Countries
                .Find(id);

            return result;
        }
    }
}
