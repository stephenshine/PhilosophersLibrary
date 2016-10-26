using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhilosophersLibrary.Models.Entities;

namespace PhilosophersLibrary.DAL
{
    public class PhilosopherInitialiser : System.Data.Entity.DropCreateDatabaseIfModelChanges<PhilosopherContext>
    {
        protected override void Seed(PhilosopherContext context)
        {
            var philosophers = new List<Philosopher>{
                new Philosopher {
                    FirstName = "Bertrand",
                    LastName = "Russell",
                    DateOfBirth = DateTime.Parse("1872-05-18"),
                    DateOfDeath = DateTime.Parse("1970-02-02"),
                    IsAlive = false,
                    NationalityID = 1,
                    AreaID = 7,
                    Description = "Here's some text about Bertrand Russell"
                },
                new Philosopher {
                    FirstName = "Immanuel",
                    LastName = "Kant",
                    DateOfBirth = DateTime.Parse("1724-04-22"),
                    DateOfDeath = DateTime.Parse("1804-02-12"),
                    IsAlive = false,
                    NationalityID = 3,
                    AreaID = 1,
                    Description = "Here's some text about Immanuel Kant"
                },
                new Philosopher {
                    FirstName = "John",
                    LastName = "Rawls",
                    DateOfBirth = DateTime.Parse("1921-02-21"),
                    DateOfDeath = DateTime.Parse("2002-11-24"),
                    IsAlive = false,
                    NationalityID = 9,
                    AreaID = 3,
                    Description = "Here's some text about John Rawls"
                }
            };
            philosophers.ForEach(p => context.Philosophers.Add(p));
            context.SaveChanges();

            var nationalities = new List<Nationality>
            {
                new Nationality { Name = "English" },
                new Nationality { Name = "Scotish" },
                new Nationality { Name = "German" },
                new Nationality { Name = "French" },
                new Nationality { Name = "Greek" },
                new Nationality { Name = "Italian" },
                new Nationality { Name = "Spanish" },
                new Nationality { Name = "Russian" },
                new Nationality { Name = "American" }
            };
            nationalities.ForEach(n => context.Nationalities.Add(n));
            context.SaveChanges();

            var areas = new List<Area>{
                new Area { Name = "Metaphysics" },
                new Area { Name = "Existentialism" },
                new Area { Name = "Political philosophy" },
                new Area { Name = "Philosophy of the mind" },
                new Area { Name = "Aesthetics" },
                new Area { Name = "Social philosophy" },
                new Area { Name = "Logic" },
                new Area { Name = "Moral philosophy" },
                new Area { Name = "Epistemology" }
            };
            areas.ForEach(a => context.Areas.Add(a));
            context.SaveChanges();

            var books = new List<Book>
            {
                new Book {
                    Title = "The impact of science on society",
                    PhilosopherID = 1,
                    AreaID = 6
                },
                new Book {
                    Title = "The analysis of mind",
                    PhilosopherID = 1,
                    AreaID = 4
                },
                new Book {
                    Title = "Marriage and morals",
                    PhilosopherID = 1,
                    AreaID = 8
                },
                new Book{
                    Title = "Critique of pure reason",
                    PhilosopherID = 2,
                    AreaID = 9
                },
                new Book{
                    Title = "The metaphysics of morals",
                    PhilosopherID = 2,
                    AreaID = 8
                },
                new Book{
                    Title = "A theory of justice",
                    PhilosopherID = 3,
                    AreaID = 3
                }
            };
            books.ForEach(b => context.Books.Add(b));
            context.SaveChanges();
        }
    }
}