namespace BeeSoft.Services.Hives;

using BeeSoft.Services.Hives.Models;

public interface IHivesService
{
    Task<ICollection<HiveServiceModel>> GetHives();

    Task<HiveServiceModel?> GetByIdAsync(int id);

    Task<int> CreateAsync(HiveServiceModel model);

    Task UpdateAsync(HiveServiceModel model);

    Task<bool> DeleteAsync(int id);
}
