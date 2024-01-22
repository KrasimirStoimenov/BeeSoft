namespace BeeSoft.Services.Inspections;

using BeeSoft.Services.Inspections.Models;

public interface IInspectionsService
{
    Task<ICollection<InspectionServiceModel>> GetInspectionsAsync();

    Task<InspectionServiceModel?> GetByIdAsync(int id);

    Task<int> CreateAsync(InspectionServiceModel model);

    Task UpdateAsync(InspectionServiceModel model);

    Task<bool> DeleteAsync(int id);
}
