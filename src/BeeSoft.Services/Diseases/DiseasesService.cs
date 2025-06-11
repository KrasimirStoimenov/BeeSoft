namespace BeeSoft.Services.Diseases;

using BeeSoft.Data;
using BeeSoft.Services.Diseases.Mappings;
using BeeSoft.Services.Diseases.Models;

using Microsoft.EntityFrameworkCore;

public sealed class DiseasesService(BeeSoftDbContext dbContext) : IDiseasesService
{
    public async Task<ICollection<DiseaseListingServiceModel>> GetDiseasesAsync()
        => await dbContext.Diseases
            .Include(h => h.Hive)
            .OrderByDescending(x => x.Id)
            .ProjectToDiseaseListingServiceModel()
            .ToListAsync();

    public async Task<ICollection<DiseaseListingServiceModel>> GetDiseasesForHiveAsync(int hiveId)
        => await dbContext.Diseases
            .Where(x => x.HiveId == hiveId)
            .Include(a => a.Hive)
            .ProjectToDiseaseListingServiceModel()
            .ToListAsync();

    public async Task<BaseDiseaseServiceModel?> GetByIdAsync(int id)
        => await dbContext.Diseases
                .Where(p => p.Id == id)
                .ProjectToBaseDiseaseServiceModel()
                .FirstOrDefaultAsync();

    public async Task<int> CreateAsync(BaseDiseaseServiceModel model)
    {
        var disease = model.MapToDisease();

        await dbContext.Diseases.AddAsync(disease);
        await dbContext.SaveChangesAsync();

        return disease.Id;
    }

    public async Task UpdateAsync(BaseDiseaseServiceModel model)
    {
        var disease = model.MapToDisease();

        dbContext.Update(disease);
        await dbContext.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            var disease = await dbContext.Diseases.FirstOrDefaultAsync(a => a.Id == id);

            if (disease == null)
            {
                return false;
            }


            dbContext.Diseases.Remove(disease);
            await dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
