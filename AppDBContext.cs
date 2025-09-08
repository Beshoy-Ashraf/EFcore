using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace ConsoleApp1;

public class AppDBContext : DbContext
{

      public DbSet<wallet> wallet { get; set; } = null!;
      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
            base.OnConfiguring(optionsBuilder);
            var configuration = new ConfigurationBuilder()
                  .AddJsonFile("applicationsetting.json")
                  .Build();
            var constr = configuration.GetSection("const").Value;

            optionsBuilder.UseNpgsql(constr);
      }
}
