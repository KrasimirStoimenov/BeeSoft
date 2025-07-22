namespace BeeSoft.Data;

using BeeSoft.Data.Models;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class BeeSoftDbContext(DbContextOptions<BeeSoftDbContext> options) : IdentityDbContext(options)
{
    public required DbSet<Apiary> Apiaries { get; init; }

    public required DbSet<Hive> Hives { get; init; }

    public required DbSet<BeeQueen> BeeQueens { get; init; }

    public required DbSet<Harvest> Harvests { get; init; }

    public required DbSet<Inspection> Inspections { get; init; }

    public required DbSet<Disease> Diseases { get; init; }

    public required DbSet<Expense> Expenses { get; init; }
}
