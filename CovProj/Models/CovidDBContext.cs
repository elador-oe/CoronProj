using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CovProj.Models
{
    public class CovidDBContext : DbContext
    {
        public DbSet<Peoples> peoples { get; set; }
        public DbSet<Healty> healties { get; set; }
        public DbSet<InfecPlaces> infectedlaces{ get; set; }
        public DbSet<Isolated> isolateds { get; set; }
        public DbSet<Recovering> recoverings { get; set; }
        public DbSet<Sick> sicks { get; set; }

    }
}