namespace BeeSoft.Services.Harvests;

using BeeSoft.Services.Harvests.Models;

public interface IHarvestsService
{
    Task<ICollection<HarvestListingServiceModel>> GetHarvestsAsync();

    Task<BaseHarvestServiceModel?> GetByIdAsync(int id);

    Task<int> CreateAsync(BaseHarvestServiceModel model);

    Task UpdateAsync(BaseHarvestServiceModel model);

    Task<bool> DeleteAsync(int id);
}
