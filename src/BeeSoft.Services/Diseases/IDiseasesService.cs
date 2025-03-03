﻿namespace BeeSoft.Services.Diseases;

using BeeSoft.Services.Diseases.Models;

public interface IDiseasesService
{
    Task<ICollection<DiseaseListingServiceModel>> GetDiseasesAsync();

    Task<ICollection<DiseaseListingServiceModel>> GetDiseasesForHiveAsync(int hiveId);

    Task<BaseDiseaseServiceModel?> GetByIdAsync(int id);

    Task<int> CreateAsync(BaseDiseaseServiceModel model);

    Task UpdateAsync(BaseDiseaseServiceModel model);

    Task<bool> DeleteAsync(int id);
}
