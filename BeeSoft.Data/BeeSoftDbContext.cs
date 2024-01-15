namespace BeeSoft.Data;

using BeeSoft.Data.Models;

using Microsoft.EntityFrameworkCore;

public class BeeSoftDbContext : DbContext
{
    public BeeSoftDbContext(DbContextOptions<BeeSoftDbContext> options)
        : base(options)
    {
    }

    public DbSet<Apiary> Apiaries { get; init; }

    public DbSet<Beehive> Beehives { get; init; }

    public DbSet<BeeQueen> BeeQueens { get; init; }
}
