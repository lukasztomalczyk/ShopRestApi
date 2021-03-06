﻿using DataAccessLayer.Entities;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerAddress>()
                .HasKey(ca => new { ca.AddressId, ca.CustomerId });

            modelBuilder.Entity<CustomerAddress>()
                .HasOne(ca => ca.Address)
                .WithMany(a => a.Customers)
                .HasForeignKey(ca => ca.AddressId);

            modelBuilder.Entity<CustomerAddress>()
                .HasOne(ca => ca.Customer)
                .WithMany(c => c.Addresses)
                .HasForeignKey(ca => ca.CustomerId);

            base.OnModelCreating(modelBuilder);
        }
       
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders{ get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
