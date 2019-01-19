using System;
using System.Collections.Generic;
using System.Text;
using CrabZinc.Common.Entities;
using CrabZinc.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace CrabZinc.Data
{
    public class CrabZincDbContext : DbContext
    {

        public DbSet<Post> Posts { get; set; }

        public CrabZincDbContext(DbContextOptions<CrabZincDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PostMap());

        }

    }
}
