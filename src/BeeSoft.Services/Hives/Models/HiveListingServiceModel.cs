namespace BeeSoft.Services.Hives.Models;
public record HiveListingServiceModel : BaseHiveServiceModel
{
    public required string ApiaryName { get; init; }
}
