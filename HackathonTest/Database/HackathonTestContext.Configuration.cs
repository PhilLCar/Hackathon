using Microsoft.EntityFrameworkCore;

namespace HackathonTest.Database;

public partial class HackathonTestContext : DbContext
{
  public HackathonTestContext() { }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseNpgsql($"Database=HackathonTest;Username=postgres;Host=127.0.0.1;Password={Environment.GetEnvironmentVariable("POSTGRES_PASSWORD")};Persist Security Info=True");
}