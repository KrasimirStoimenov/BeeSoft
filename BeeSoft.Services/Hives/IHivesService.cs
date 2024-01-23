namespace BeeSoft.Services.Hives;

using BeeSoft.Services.Hives.Models;

public interface IHivesService
{
    Task<ICollection<HiveServiceModel>> GetHivesAsync();

    Task<HiveServiceModel?> GetByIdAsync(int id);

    Task<int> CreateAsync(HiveServiceModel model);

    Task UpdateAsync(HiveServiceModel model);

    Task<bool> DeleteAsync(int id);

    Task<bool> IsHiveExistsAsync(int id);

    Task<bool> IsHiveWithNumberAlreadyExists(int hiveNumber);
}
