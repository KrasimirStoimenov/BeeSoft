namespace BeeSoft.Services.Diseases;

using BeeSoft.Services.Diseases.Models;

public interface IDiseasesService
{
    Task<ICollection<DiseaseServiceModel>> GetDiseasesAsync();

    Task<DiseaseServiceModel?> GetByIdAsync(int id);

    Task<int> CreateAsync(DiseaseServiceModel model);

    Task UpdateAsync(DiseaseServiceModel model);

    Task<bool> DeleteAsync(int id);
}
