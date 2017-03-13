using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoyoTournaments.Data.Contracts;
using YoyoTournaments.Data.Migrations;
using YoyoTournaments.Models;

namespace YoyoTournaments.Data
{
    public class YoyoTournamentsDbContext : DbContext, IYoyoTournamentsDbContext
    {
        public YoyoTournamentsDbContext()
            : base("DefaultConnectionTest")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<YoyoTournamentsDbContext, Configuration>());
        }

        public IDbSet<Player> Players { get; set; }

        public IDbSet<Tournament> Tournaments { get; set; }

        public IDbSet<Country> Countries { get; set; }

        public IDbSet<DivisionType> DivisionTypes { get; set; }

        public IDbSet<Division> Divisions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
