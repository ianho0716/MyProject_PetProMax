using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PetproMax.Models
{
    public class PetproContext : DbContext
    {
        public PetproContext() : base("name=PetproConnection")
        { }


        public DbSet<Employees> Employees { get; set; }
        public DbSet<Members> Members { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<PayTypes> PayTypes { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Shippers> Shippers { get; set; }
        public DbSet<Applied> Applied { get; set; }
        public DbSet<HomeLessAnimal> HomeLessAnimals { get; set; }
        public DbSet<FindPet> FindPets { get; set; }
    }
}