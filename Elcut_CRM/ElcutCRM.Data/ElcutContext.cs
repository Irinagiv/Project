using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using ElcutCRM.Data.Models;

namespace ElcutCRM.Data
{
    public class ElcutContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Organization> Organizations { get; set; }

        public DbSet<OrganizationType> OrganizationTypes { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderType> OrderTypes { get; set; }

        public DbSet<ContactName> ContactNames { get; set; }

        public DbSet<ConfigurationOption> ConfigurationOptions { get; set; }

        public DbSet<OptionPrice> OptionPrices { get; set; }

        public DbSet<OrderConfiguration> OrderConfigurations { get; set; }

        public DbSet<DictionaryEntry> DictionaryEntries { get; set; }

        public DbSet<History> Histories { get; set; }

        public DbSet<Document> Documents { get; set; }

        public ElcutContext() : base("Elcut_CRM") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingEntitySetNameConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
