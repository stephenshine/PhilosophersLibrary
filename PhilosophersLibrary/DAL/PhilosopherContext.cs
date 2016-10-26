﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhilosophersLibrary.Models.Entities;
using System.Data.Entity;

namespace PhilosophersLibrary.DAL
{
    public class PhilosopherContext : DbContext
    {
        public PhilosopherContext() : base("PhilosopherContext") { }

        public DbSet<Philosopher> Philosophers { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<Book> Books { get; set; }

    }
}