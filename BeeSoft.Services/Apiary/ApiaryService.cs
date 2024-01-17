namespace BeeSoft.Services.Apiary;

using System.Threading.Tasks;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using BeeSoft.Data;
using BeeSoft.Services.Apiary.Models;

using Microsoft.EntityFrameworkCore;

public sealed class ApiaryService(BeeSoftDbContext dbContext, IMapper mapper) : IApiaryService
{
    public async Task<ICollection<ApiaryServiceModel>> GetApiaries()
        => await dbContext.Apiaries
            .OrderByDescending(p => p.Id)
            .ProjectTo<ApiaryServiceModel>(mapper.ConfigurationProvider)
            .ToListAsync();

    public async Task<ApiaryServiceModel> GetByIdAsync(int id)
        => await dbContext.Apiaries
                 .Where(p => p.Id == id)
                 .ProjectTo<ApiaryServiceModel>(mapper.ConfigurationProvider)
                 .FirstAsync();

    public async Task<int> CreateAsync(string name, string location)
    {
        var apiary = new Data.Models.Apiary
        {
            Name = name,
            Location = location
        };

        await dbContext.Apiaries.AddAsync(apiary);
        await dbContext.SaveChangesAsync();

        return apiary.Id;
    }

    public Task EditAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var apiary = await dbContext.Apiaries
            .FirstOrDefaultAsync(a => a.Id == id);

        if (apiary == null)
        {
            return false;
        }

        dbContext.Apiaries.Remove(apiary);
        await dbContext.SaveChangesAsync();

        return true;
    }
}
