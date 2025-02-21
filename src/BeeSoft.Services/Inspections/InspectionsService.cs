namespace BeeSoft.Services.Inspections;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using BeeSoft.Data;
using BeeSoft.Data.Models;
using BeeSoft.Services.Inspections.Models;

using Microsoft.EntityFrameworkCore;

public sealed class InspectionsService(BeeSoftDbContext dbContext, IMapper mapper) : IInspectionsService
{
    public async Task<ICollection<InspectionListingServiceModel>> GetInspectionsAsync()
        => await dbContext.Inspections
            .Include(h => h.Hive)
            .OrderByDescending(x => x.Id)
            .ProjectTo<InspectionListingServiceModel>(mapper.ConfigurationProvider)
            .ToListAsync();

    public async Task<ICollection<InspectionListingServiceModel>> GetInspectionsForHiveAsync(int hiveId)
        => await dbContext.Inspections
            .Where(x => x.HiveId == hiveId)
            .Include(a => a.Hive)
            .OrderByDescending(x => x.Id)
            .ProjectTo<InspectionListingServiceModel>(mapper.ConfigurationProvider)
            .ToListAsync();

    public async Task<BaseInspectionServiceModel?> GetByIdAsync(int id)
        => await dbContext.Inspections
              .Where(p => p.Id == id)
              .ProjectTo<BaseInspectionServiceModel>(mapper.ConfigurationProvider)
              .FirstOrDefaultAsync();

    public async Task<int> CreateAsync(BaseInspectionServiceModel model)
    {
        var inspection = mapper.Map<Inspection>(model);

        await dbContext.Inspections.AddAsync(inspection);
        await dbContext.SaveChangesAsync();

        return inspection.Id;
    }

    public async Task UpdateAsync(BaseInspectionServiceModel model)
    {
        var inspection = mapper.Map<Inspection>(model);

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
