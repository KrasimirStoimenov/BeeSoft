namespace BeeSoft.Services.Apiaries;

using System.Threading.Tasks;

using BeeSoft.Data;
using BeeSoft.Services.Apiaries.Mappings;
using BeeSoft.Services.Apiaries.Models;

using Microsoft.EntityFrameworkCore;

public sealed class ApiariesService(BeeSoftDbContext dbContext) : IApiariesService
{
    public async Task<ICollection<ApiaryServiceModel>> GetApiariesAsync()
        => await dbContext.Apiaries
            .OrderByDescending(p => p.Id)
            .ProjectToApiaryServiceModel()
            .ToListAsync();

    public async Task<ApiaryServiceModel?> GetByIdAsync(int id)
        => await dbContext.Apiaries
            .Where(p => p.Id == id)
            .ProjectToApiaryServiceModel()
            .FirstOrDefaultAsync();

    public async Task<int> CreateAsync(ApiaryServiceModel apiaryServiceModel)
    {
        if (await IsApiaryExistsAsync(apiaryServiceModel.Name, apiaryServiceModel.Location))
        {
            throw new InvalidOperationException($"Apiary with name: '{apiaryServiceModel.Name}' in location: '{apiaryServiceModel.Location}' already exists.");
        }

        var apiary = apiaryServiceModel.MapToApiary();

        await dbContext.Apiaries.AddAsync(apiary);
        await dbContext.SaveChangesAsync();

        return apiary.Id;
    }

    public async Task UpdateAsync(ApiaryServiceModel apiaryServiceModel)
    {
        var apiary = apiaryServiceModel.MapToApiary();

        dbContext.Update(apiary);
        await dbContext.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            var apiary = await dbContext.Apiaries.FirstOrDefaultAsync(a => a.Id == id);

            if (apiary == null)
            {
                return false;
            }


            dbContext.Apiaries.Remove(apiary);
            await dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<bool> IsApiaryExistsAsync(int id)
        => await dbContext.Apiaries
            .AnyAsync(a => a.Id == id);

    public async Task<bool> IsApiaryExistsAsync(string name, string location)
        => await dbContext.Apiaries
            .AnyAsync(a => a.Name == name && a.Location == location);
}
