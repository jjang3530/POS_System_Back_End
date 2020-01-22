using Dima3API.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dima3API.Data
{
    public class Dima3APIContext : DbContext
    {
        public Dima3APIContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Menus> Menus { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<Tables> Tables { get; set; }
    }
}
