namespace BeeSoft.Services.Apiary;

using System.Threading.Tasks;

using BeeSoft.Data;

using Microsoft.EntityFrameworkCore;

public sealed class ApiaryService(BeeSoftDbContext dbContext) : IApiaryService
{
    public Task GetApiaryByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> CreateAsync()
    {
        var apiary = new Data.Models.Apiary
        {
            Name = "TestApiaryName",
            Location = "TestApiaryLocation"
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
