﻿namespace BeeSoft.Data;

using BeeSoft.Data.Models;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class BeeSoftDbContext(DbContextOptions<BeeSoftDbContext> options) : IdentityDbContext(options)
{
    public DbSet<Apiary> Apiaries { get; init; }

    public DbSet<Hive> Hives { get; init; }

    public DbSet<BeeQueen> BeeQueens { get; init; }

    public DbSet<Harvest> Harvests { get; init; }

    public DbSet<Inspection> Inspections { get; init; }

    public DbSet<Disease> Diseases { get; init; }

    public DbSet<Expense> Expenses { get; init; }
}
