namespace BeeSoft.Services.Harvests;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using BeeSoft.Data;
using BeeSoft.Data.Models;
using BeeSoft.Services.Harvests.Models;

using Microsoft.EntityFrameworkCore;

public sealed class HarvestsService(BeeSoftDbContext dbContext, IMapper mapper) : IHarvestsService
{
    public async Task<ICollection<HarvestServiceModel>> GetHarvestsAsync()
        => await dbContext.Harvests
            .OrderByDescending(x => x.Id)
            .ProjectTo<HarvestServiceModel>(mapper.ConfigurationProvider)
            .ToListAsync();

    public async Task<HarvestServiceModel?> GetByIdAsync(int id)
        => await dbContext.Harvests
                .Where(p => p.Id == id)
                .ProjectTo<HarvestServiceModel>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

    public async Task<int> CreateAsync(HarvestServiceModel model)
    {
        var harvest = mapper.Map<Harvest>(model);

        await dbContext.Harvests.AddAsync(harvest);
        await dbContext.SaveChangesAsync();

        return harvest.Id;
    }

    public async Task UpdateAsync(HarvestServiceModel model)
    {
        var harvest = mapper.Map<Harvest>(model);

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
