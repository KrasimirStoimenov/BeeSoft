namespace BeeSoft.Data.Models;

using System.ComponentModel.DataAnnotations;

using static Common.DataAttributeConstants.Expense;

public class Expense
{
    [Key]
    public int Id { get; init; }

    [Required]
    [MaxLength(NameMaxLength)]
    public required string Name { get; init; }

    public decimal Price { get; init; }

    public DateOnly Date { get; init; }
}
