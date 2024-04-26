namespace BeeSoft.Services.BeeQueens;

using BeeSoft.Services.BeeQueens.Models;

public interface IBeeQueensService
{
    Task<ICollection<BeeQueenListingServiceModel>> GetBeeQueensAsync();

    Task<ICollection<BeeQueenListingServiceModel>> GetBeeQueensInHiveAsync(int hiveId);

    Task<BaseBeeQueenServiceModel?> GetByIdAsync(int id);

    Task<int> CreateAsync(BaseBeeQueenServiceModel model);

    Task UpdateAsync(BaseBeeQueenServiceModel model);

    Task<bool> DeleteAsync(int id);
}
