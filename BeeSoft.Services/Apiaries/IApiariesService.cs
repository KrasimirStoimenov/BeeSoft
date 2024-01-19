namespace BeeSoft.Services.Apiaries;

using BeeSoft.Services.Apiaries.Models;

public interface IApiariesService
{
    Task<ICollection<ApiaryServiceModel>> GetApiaries();

    Task<ApiaryServiceModel?> GetByIdAsync(int id);

    Task<int> CreateAsync(ApiaryServiceModel model);

    Task UpdateAsync(ApiaryServiceModel model);

    Task<bool> DeleteAsync(int id);
}
