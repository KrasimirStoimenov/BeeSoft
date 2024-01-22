namespace BeeSoft.Services.Harvests;

using BeeSoft.Services.Harvests.Models;

public interface IHarvestsService
{
    Task<ICollection<HarvestServiceModel>> GetHarvestsAsync();

    Task<HarvestServiceModel?> GetByIdAsync(int id);

    Task<int> CreateAsync(HarvestServiceModel model);

    Task UpdateAsync(HarvestServiceModel model);

    Task<bool> DeleteAsync(int id);
}
