namespace BeeSoft.Services.Inspections;

using BeeSoft.Services.Inspections.Models;

public interface IInspectionsService
{
    Task<ICollection<InspectionListingServiceModel>> GetInspectionsAsync();

    Task<ICollection<InspectionListingServiceModel>> GetInspectionsForHiveAsync(int hiveId);

    Task<BaseInspectionServiceModel?> GetByIdAsync(int id);

    Task<int> CreateAsync(BaseInspectionServiceModel model);

    Task UpdateAsync(BaseInspectionServiceModel model);

    Task<bool> DeleteAsync(int id);
}
