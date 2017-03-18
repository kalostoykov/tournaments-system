using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoyoTournaments.Authentication;
using YoyoTournaments.Data.Contracts;
using YoyoTournaments.Data.Migrations;
using YoyoTournaments.Models;

namespace YoyoTournaments.Data
{
    public class YoyoTournamentsDbContext : IdentityDbContext<ApplicationUser>, IYoyoTournamentsDbContext
    {
        public YoyoTournamentsDbContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<YoyoTournamentsDbContext, Configuration>());
        }

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
