using System;
using Microsoft.EntityFrameworkCore;
using WhatWeGot.Model;

namespace WhatWeGot.DataAccess
{
    public class WhatWeGotContext : DbContext
    {
        public WhatWeGotContext(DbContextOptions<WhatWeGotContext> options) : base(options)
        {
        }

        public DbSet<FinanceItem> Items { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FinanceItem>().ToTable("Ledger");
            modelBuilder.Entity<Category>().ToTable("Category");
        }
    }
}
