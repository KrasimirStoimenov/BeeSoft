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
    public async Task<ICollection<BeeQueenServiceModel>> GetBeeQueensAsync()
        => await dbContext.BeeQueens
            .OrderByDescending(x => x.Id)
            .ProjectTo<BeeQueenServiceModel>(mapper.ConfigurationProvider)
            .ToListAsync();

    public async Task<BeeQueenServiceModel?> GetByIdAsync(int id)
        => await dbContext.BeeQueens
            .Where(p => p.Id == id)
            .ProjectTo<BeeQueenServiceModel>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();

    public async Task<int> CreateAsync(BeeQueenServiceModel model)
    {
        var beeQueen = mapper.Map<BeeQueen>(model);

        await dbContext.BeeQueens.AddAsync(beeQueen);
        await dbContext.SaveChangesAsync();

        return beeQueen.Id;
    }

    public async Task UpdateAsync(BeeQueenServiceModel model)
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
