namespace PhilosophersLibrary.Migrations
{
    using Models.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PhilosophersLibrary.DAL.PhilosopherContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PhilosophersLibrary.DAL.PhilosopherContext context)
        {
            context.Philosopher.AddOrUpdate(p => p.LastName,
                new Philosopher
                {
                    FirstName = "Bertrand",
                    LastName = "Russell",
                    DateOfBirth = DateTime.Parse("1872-05-18"),
                    DateOfDeath = DateTime.Parse("1970-02-02"),
                    IsAlive = false,
                    NationalityID = 1,
                    AreaID = 7,
                    Description = "Here's some text about Bertrand Russell"
                },
                new Philosopher
                {
                    FirstName = "Immanuel",
                    LastName = "Kant",
                    DateOfBirth = DateTime.Parse("1724-04-22"),
                    DateOfDeath = DateTime.Parse("1804-02-12"),
                    IsAlive = false,
                    NationalityID = 3,
                    AreaID = 1,
                    Description = "Here's some text about Immanuel Kant"
                },
                new Philosopher
                {
                    FirstName = "John",
                    LastName = "Rawls",
                    DateOfBirth = DateTime.Parse("1921-02-21"),
                    DateOfDeath = DateTime.Parse("2002-11-24"),
                    IsAlive = false,
                    NationalityID = 9,
                    AreaID = 3,
                    Description = "Here's some text about John Rawls"
                }
                );
        }
    }
}
