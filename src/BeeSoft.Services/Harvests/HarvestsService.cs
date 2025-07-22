namespace BeeSoft.Services.Harvests;

using BeeSoft.Data;
using BeeSoft.Services.Harvests.Mappings;
using BeeSoft.Services.Harvests.Models;

using Microsoft.EntityFrameworkCore;

public sealed class HarvestsService(BeeSoftDbContext dbContext) : IHarvestsService
{
    public async Task<ICollection<HarvestListingServiceModel>> GetHarvestsAsync()
        => await dbContext.Harvests
            .Include(h => h.Hive)
            .OrderByDescending(x => x.Id)
            .ProjectToHarvestListingServiceModel()
            .ToListAsync();

    public async Task<ICollection<HarvestListingServiceModel>> GetHarvestsForHiveAsync(int hiveId)
        => await dbContext.Harvests
            .Where(x => x.HiveId == hiveId)
            .Include(a => a.Hive)
            .OrderByDescending(x => x.Id)
            .ProjectToHarvestListingServiceModel()
            .ToListAsync();

    public async Task<BaseHarvestServiceModel?> GetByIdAsync(int id)
        => await dbContext.Harvests
                .Where(p => p.Id == id)
                .ProjectToBaseHarvestServiceModel()
                .FirstOrDefaultAsync();

    public async Task<int> CreateAsync(BaseHarvestServiceModel model)
    {
        var harvest = model.MapToHarvest();

        await dbContext.Harvests.AddAsync(harvest);
        await dbContext.SaveChangesAsync();

        return harvest.Id;
    }

    public async Task UpdateAsync(BaseHarvestServiceModel model)
    {
        var harvest = model.MapToHarvest();

        dbContext.Update(harvest);
        await dbContext.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            var harvest = await dbContext.Harvests.FirstOrDefaultAsync(a => a.Id == id);

            if (harvest == null)
            {
                return false;
            }


            dbContext.Harvests.Remove(harvest);
            await dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
