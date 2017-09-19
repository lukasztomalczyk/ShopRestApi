using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Context
{
    class ContextDB : DbContext
    {
        static DbContextOptions<ContextDB> options =
      new DbContextOptionsBuilder<ContextDB>()
                   .UseInMemoryDatabase("TheDB")
                   .Options;

        
        public ContextDB() : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders{ get; set; }
        public DbSet<Adress> Adressess { get; set; }
    }
}
