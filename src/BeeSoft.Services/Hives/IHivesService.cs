﻿namespace BeeSoft.Services.Hives;

using BeeSoft.Services.Hives.Models;

public interface IHivesService
{
    Task<ICollection<HiveListingServiceModel>> GetHivesAsync();

    Task<ICollection<BaseHiveServiceModel>> GetHivesInApiaryAsync(int apiaryId);

    Task<ICollection<BaseHiveServiceModel>> GetHivesWithoutQueenAsync();

    Task<BaseHiveServiceModel?> GetByIdAsync(int id);

    Task<HiveDetailsServiceModel?> GetDetailsByIdAsync(int id);

    Task<int> CreateAsync(BaseHiveServiceModel model);

    Task UpdateAsync(BaseHiveServiceModel model);

    Task<bool> DeleteAsync(int id);

    Task<bool> IsHiveExistsAsync(int id);

    Task<bool> IsHiveWithNumberAlreadyExists(int hiveNumber);
}
