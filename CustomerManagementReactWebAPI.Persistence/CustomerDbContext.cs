using CustomerManagementReactWebAPI.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementReactWebAPI.Persistence
{
    public class CustomerDbContext : DbContext
    {
        private static bool _created = false;

        public CustomerDbContext(DbContextOptions options) : base(options)
        {
            // just for testing purposes we recreate DB every run
            if (!_created)
            {
                _created = true;
                Database.EnsureDeleted();
                Database.EnsureCreated();
            }
        }

        public DbSet<Customer> Employees { get; set; }
    }
}
