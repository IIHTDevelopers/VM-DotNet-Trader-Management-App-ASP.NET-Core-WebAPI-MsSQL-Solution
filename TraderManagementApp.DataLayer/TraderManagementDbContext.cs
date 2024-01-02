using Microsoft.EntityFrameworkCore;
using TraderManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TraderManagementApp.DataLayer
{
    public class TraderManagementAppDbContext : DbContext
    {
        public TraderManagementAppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Trader> Traders { get; set; }
    }

}