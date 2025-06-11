namespace BeeSoft.Services.BeeQueens;

using System.Collections.Generic;
using System.Threading.Tasks;

using BeeSoft.Data;
using BeeSoft.Services.BeeQueens.Mappings;
using BeeSoft.Services.BeeQueens.Models;

using Microsoft.EntityFrameworkCore;

public sealed class BeeQueensService(BeeSoftDbContext dbContext) : IBeeQueensService
{
    public async Task<ICollection<BeeQueenListingServiceModel>> GetBeeQueensAsync()
        => await dbContext.BeeQueens
            .Include(h => h.Hive)
            .OrderByDescending(x => x.Id)
            .ProjectToBeeQueenListingServiceModel()
            .ToListAsync();

    public async Task<ICollection<BeeQueenListingServiceModel>> GetBeeQueensInHiveAsync(int hiveId)
        => await dbContext.BeeQueens
            .Where(x => x.HiveId == hiveId)
            .Include(a => a.Hive)
            .ProjectToBeeQueenListingServiceModel()
            .ToListAsync();

    public async Task<BaseBeeQueenServiceModel?> GetByIdAsync(int id)
        => await dbContext.BeeQueens
            .Where(p => p.Id == id)
            .ProjectToBaseBeeQueenServiceModel()
            .FirstOrDefaultAsync();

    public async Task<int> CreateAsync(BaseBeeQueenServiceModel model)
    {
        var beeQueen = model.MapToBeeQueen();

        await dbContext.BeeQueens.AddAsync(beeQueen);
        await dbContext.SaveChangesAsync();

        return beeQueen.Id;
    }

    public async Task UpdateAsync(BaseBeeQueenServiceModel model)
    {
        var beeQueen = model.MapToBeeQueen();

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
