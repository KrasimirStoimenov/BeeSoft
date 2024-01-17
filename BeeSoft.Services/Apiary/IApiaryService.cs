namespace BeeSoft.Services.Apiary;
using BeeSoft.Services.Apiary.Models;

public interface IApiaryService
{
    Task<ICollection<ApiaryServiceModel>> GetApiaries();

    Task<ApiaryServiceModel> GetByIdAsync(int id);

    Task<int> CreateAsync(string name, string location);

    Task EditAsync();

    Task<bool> DeleteAsync(int id);
}
