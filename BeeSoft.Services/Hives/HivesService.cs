namespace BeeSoft.Services.Hives;

using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using BeeSoft.Data;
using BeeSoft.Data.Models;
using BeeSoft.Services.Hives.Models;

using Microsoft.EntityFrameworkCore;

public sealed class HivesService(BeeSoftDbContext dbContext, IMapper mapper) : IHivesService
{
    public async Task<ICollection<HiveListingServiceModel>> GetHivesAsync()
        => await dbContext.Hives
            .Include(a => a.Apiary)
            .OrderByDescending(x => x.Number)
            .ProjectTo<HiveListingServiceModel>(mapper.ConfigurationProvider)
            .ToListAsync();

    public async Task<ICollection<BaseHiveServiceModel>> GetHivesWithoutQueenAsync()
        => await dbContext.Hives
            .Include(bq => bq.BeeQueens)
            .Where(h => h.BeeQueens.Count == 0 || h.BeeQueens.Any(bq => !bq.IsAlive))
            .OrderByDescending(x => x.Number)
            .ProjectTo<BaseHiveServiceModel>(mapper.ConfigurationProvider)
            .ToListAsync();

    public async Task<BaseHiveServiceModel?> GetByIdAsync(int id)
        => await dbContext.Hives
            .Where(p => p.Id == id)
            .ProjectTo<BaseHiveServiceModel>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();

    public async Task<int> CreateAsync(BaseHiveServiceModel model)
    {
        var hive = mapper.Map<Hive>(model);

        await dbContext.Hives.AddAsync(hive);
        await dbContext.SaveChangesAsync();

        return hive.Id;
    }

    public async Task UpdateAsync(BaseHiveServiceModel model)
    {
        var hive = mapper.Map<Hive>(model);

        dbContext.Update(hive);
        await dbContext.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            var hive = await dbContext.Hives.FirstOrDefaultAsync(a => a.Id == id);

            if (hive == null)
            {
                return false;
            }


            dbContext.Hives.Remove(hive);
            await dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<bool> IsHiveExistsAsync(int id)
        => await dbContext.Hives
            .AnyAsync(c => c.Id == id);

    public async Task<bool> IsHiveWithNumberAlreadyExists(int hiveNumber)
        => await dbContext.Hives
            .AnyAsync(h => h.Number == hiveNumber);
}
