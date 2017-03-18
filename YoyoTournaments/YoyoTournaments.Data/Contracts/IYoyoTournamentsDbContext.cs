using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoyoTournaments.Models;

namespace YoyoTournaments.Data.Contracts
{
    public interface IYoyoTournamentsDbContext
    {
        IDbSet<Tournament> Tournaments { get; set; }

        IDbSet<Country> Countries { get; set; }

        IDbSet<DivisionType> DivisionTypes { get; set; }

        IDbSet<Division> Divisions { get; set; }

        int SaveChanges();
    }
}
