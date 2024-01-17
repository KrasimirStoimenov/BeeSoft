﻿namespace BeeSoft.Data.Models;

using System.ComponentModel.DataAnnotations;

public class Apiary
{
    [Key]
    public int Id { get; init; }

    [Required]
    [MaxLength(100)]
    public required string Name { get; init; }

    [Required]
    [MaxLength(100)]
    public required string Location { get; init; }

    public ICollection<Hive> Hives { get; init; } = new HashSet<Hive>();
}
