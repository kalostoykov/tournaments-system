namespace YoyoTournaments.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<YoyoTournamentsDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(YoyoTournamentsDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            if (!context.Countries.Any())
            {
                var countries = new string[]
                {
                     "Austria" ,
                     "Belgium" ,
                     "Bulgaria",
                     "Croatia" ,
                     "Cyprus" ,
                     "Czech Republic" ,
                     "Denmark" ,
                     "Estonia" ,
                     "Finland" ,
                     "France" ,
                     "Gernamy" ,
                     "Greece" ,
                     "Hungary" ,
                     "Ireland" ,
                     "Italy" ,
                     "Latvia" ,
                     "Lithuania" ,
                     "Luxembourg" ,
                     "Malta" ,
                     "Netherlands" ,
                     "Poland" ,
                     "Portugal" ,
                     "Romania" ,
                     "Slovakia" ,
                     "Slovenia" ,
                     "Spain" ,
                     "Sweden" ,
                     "United Kingdom"
                };

                foreach (string country in countries)
                {
                    Country c = new Country() { Name = country };

                    context.Countries.Add(c);
                }

                context.SaveChanges();
            }

            if (!context.DivisionTypes.Any())
            {
                var divisions = new List<DivisionType>
                {
                    new DivisionType {
                        Name = "1A",
                        Description = "String trick freestyle with one long-spinning yoyo."
                    },
                    new DivisionType {
                        Name = "2A",
                        Description = "Looping freestyle with two responsive yoyos."
                    },
                    new DivisionType {
                        Name = "3A",
                        Description = "String trick freestyle with two long-spinning yoyos."
                    },
                    new DivisionType {
                        Name = "4A",
                        Description = "Freestyle with long-spinning yoyo not attached to the string. Also called \"offstring\"."
                    },
                    new DivisionType {
                        Name = "5A",
                        Description = "Freestyle with long-spinning yoyo not attached to player’s hand. Counterweight is tied to end of string. Also called \"counterweight\" or \"freehand\"."
                    }
                };

                divisions.ForEach(d => context.DivisionTypes.Add(d));
                context.SaveChanges();
            }

            if (!context.Roles.Any())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var adminRole = new IdentityRole() { Name = "Admin" };

                roleManager.Create(adminRole);

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var adminEmail = "admin@yoyo.com";
                var adminCountry = context.Countries.First();
                var adminUser = new ApplicationUser()
                {
                    Email = adminEmail,
                    UserName = adminEmail,
                    Country = adminCountry,
                    FirstName = "Admin",
                    LastName = "Admin"
                };

                userManager.Create(adminUser, "123456q");
                userManager.AddToRole(adminUser.Id, "Admin");

                context.SaveChanges();
            }
        }
    }
}
