using EGramWebV2BLayer.Entities.Models.PanelModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EGramWebV2BLayer.Entities
{
    public class EGramWebDBContext : DbContext
    {
        public EGramWebDBContext(DbContextOptions<EGramWebDBContext> options) : base(options)
        {

        }
        public DbSet<UserTypeMst> UserTypeMst { get; set; }
        public DbSet<UserMst> UserMst { get; set; }
        public DbSet<LoginHistory> LoginHistory { get; set; }
        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EGramWebDBContext>
        {
            public EGramWebDBContext CreateDbContext(string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../EGramWEB/appsettings.json").Build();
                var builder = new DbContextOptionsBuilder<EGramWebDBContext>();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                builder.UseSqlServer(connectionString);
                return new EGramWebDBContext(builder.Options);
            }
        }
    }
}
