namespace BeeSoft.Services.BeeQueens;

using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using BeeSoft.Data;
using BeeSoft.Data.Models;
using BeeSoft.Services.BeeQueens.Models;

using Microsoft.EntityFrameworkCore;

public sealed class BeeQueensService(BeeSoftDbContext dbContext, IMapper mapper) : IBeeQueensService
{
    public async Task<ICollection<BeeQueenListingServiceModel>> GetBeeQueensAsync()
        => await dbContext.BeeQueens
            .Include(h => h.Hive)
            .OrderByDescending(x => x.Id)
            .ProjectTo<BeeQueenListingServiceModel>(mapper.ConfigurationProvider)
            .ToListAsync();

    public async Task<BaseBeeQueenServiceModel?> GetByIdAsync(int id)
        => await dbContext.BeeQueens
            .Where(p => p.Id == id)
            .ProjectTo<BaseBeeQueenServiceModel>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();

    public async Task<int> CreateAsync(BaseBeeQueenServiceModel model)
    {
        var beeQueen = mapper.Map<BeeQueen>(model);

        await dbContext.BeeQueens.AddAsync(beeQueen);
        await dbContext.SaveChangesAsync();

        return beeQueen.Id;
    }

    public async Task UpdateAsync(BaseBeeQueenServiceModel model)
    {
        var beeQueen = mapper.Map<BeeQueen>(model);

        dbContext.Update(beeQueen);
        await dbContext.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            var beeQueen = await dbContext.BeeQueens.FirstOrDefaultAsync(a => a.Id == id);

            if (beeQueen == null)
            {
                return false;
            }


            dbContext.BeeQueens.Remove(beeQueen);
            await dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
