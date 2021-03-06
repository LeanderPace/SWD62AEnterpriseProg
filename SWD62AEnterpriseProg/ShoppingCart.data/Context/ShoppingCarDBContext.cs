﻿using Microsoft.EntityFrameworkCore;
using ShoppingCart.data.Models;
using ShoppingCart.domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.data.Context
{
    public class ShoppingCarDBContext : DbContext
    {
        public ShoppingCarDBContext(DbContextOptions options)
            : base(options)
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Member> Members { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
