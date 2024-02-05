namespace BeeSoft.Services.Diseases;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using BeeSoft.Data;
using BeeSoft.Data.Models;
using BeeSoft.Services.Diseases.Models;

using Microsoft.EntityFrameworkCore;

public sealed class DiseasesService(BeeSoftDbContext dbContext, IMapper mapper) : IDiseasesService
{
    public async Task<ICollection<DiseaseListingServiceModel>> GetDiseasesAsync()
        => await dbContext.Diseases
            .Include(h => h.Hive)
            .OrderByDescending(x => x.Id)
            .ProjectTo<DiseaseListingServiceModel>(mapper.ConfigurationProvider)
            .ToListAsync();

    public async Task<ICollection<DiseaseListingServiceModel>> GetDiseasesForHiveAsync(int hiveId)
        => await dbContext.Diseases
            .Where(x => x.HiveId == hiveId)
            .Include(a => a.Hive)
            .ProjectTo<DiseaseListingServiceModel>(mapper.ConfigurationProvider)
            .ToListAsync();

    public async Task<BaseDiseaseServiceModel?> GetByIdAsync(int id)
        => await dbContext.Diseases
                .Where(p => p.Id == id)
                .ProjectTo<BaseDiseaseServiceModel>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

    public async Task<int> CreateAsync(BaseDiseaseServiceModel model)
    {
        var disease = mapper.Map<Disease>(model);

        await dbContext.Diseases.AddAsync(disease);
        await dbContext.SaveChangesAsync();

        return disease.Id;
    }

    public async Task UpdateAsync(BaseDiseaseServiceModel model)
    {
        var disease = mapper.Map<Disease>(model);

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
