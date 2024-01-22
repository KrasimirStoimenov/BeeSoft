namespace BeeSoft.Services.Inspections;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using BeeSoft.Data;
using BeeSoft.Data.Models;
using BeeSoft.Services.Inspections.Models;

using Microsoft.EntityFrameworkCore;

public sealed class InspectionsService(BeeSoftDbContext dbContext, IMapper mapper) : IInspectionsService
{
    public async Task<ICollection<InspectionServiceModel>> GetInspectionsAsync()
        => await dbContext.Inspections
            .OrderByDescending(x => x.Id)
            .ProjectTo<InspectionServiceModel>(mapper.ConfigurationProvider)
            .ToListAsync();

    public async Task<InspectionServiceModel?> GetByIdAsync(int id)
        => await dbContext.Inspections
                    .Where(p => p.Id == id)
                    .ProjectTo<InspectionServiceModel>(mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync();

    public async Task<int> CreateAsync(InspectionServiceModel model)
    {
        var inspection = mapper.Map<Inspection>(model);

        await dbContext.Inspections.AddAsync(inspection);
        await dbContext.SaveChangesAsync();

        return inspection.Id;
    }

    public async Task UpdateAsync(InspectionServiceModel model)
    {
        var inspection = mapper.Map<Inspection>(model);

        dbContext.Update(inspection);
        await dbContext.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            var inspection = await dbContext.Inspections.FirstOrDefaultAsync(a => a.Id == id);

            if (inspection == null)
            {
                return false;
            }


            dbContext.Inspections.Remove(inspection);
            await dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
