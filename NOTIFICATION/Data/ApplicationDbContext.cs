using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using NOTIFICATION.Data;

namespace NOTIFICATION.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<NOTIFICATION.Data.Information> Information { get; set; }
        public DbSet<NOTIFICATION.Data.RenewHistory> RenewHistory { get; set; }
        public DbSet<NOTIFICATION.Data.Client> Clients { get; set; }
        public DbSet<NOTIFICATION.Data.HostAcccount> HostAcccounts { get; set; }
    }
}
