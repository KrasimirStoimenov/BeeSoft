namespace BeeSoft.Services.Inspections;

using BeeSoft.Data;
using BeeSoft.Services.Inspections.Mappings;
using BeeSoft.Services.Inspections.Models;

using Microsoft.EntityFrameworkCore;

public sealed class InspectionsService(BeeSoftDbContext dbContext) : IInspectionsService
{
    public async Task<ICollection<InspectionListingServiceModel>> GetInspectionsAsync()
        => await dbContext.Inspections
            .Include(h => h.Hive)
            .OrderByDescending(x => x.Id)
            .ProjectToInspectionListingServiceModel()
            .ToListAsync();

    public async Task<ICollection<InspectionListingServiceModel>> GetInspectionsForHiveAsync(int hiveId)
        => await dbContext.Inspections
            .Where(x => x.HiveId == hiveId)
            .Include(a => a.Hive)
            .OrderByDescending(x => x.Id)
            .ProjectToInspectionListingServiceModel()
            .ToListAsync();

    public async Task<BaseInspectionServiceModel?> GetByIdAsync(int id)
        => await dbContext.Inspections
              .Where(p => p.Id == id)
              .ProjectToBaseInspectionServiceModel()
              .FirstOrDefaultAsync();

    public async Task<int> CreateAsync(BaseInspectionServiceModel model)
    {
        var inspection = model.MapToInspection();

        await dbContext.Inspections.AddAsync(inspection);
        await dbContext.SaveChangesAsync();

        return inspection.Id;
    }

    public async Task UpdateAsync(BaseInspectionServiceModel model)
    {
        var inspection = model.MapToInspection();

        dbContext.Update(inspection);
        await dbContext.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            var inspection = await dbContext.Inspections.FirstOrDefaultAsync(a => a.Id == id);

            if (inspection == null)
            {
                return false;
            }


            dbContext.Inspections.Remove(inspection);
            await dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
