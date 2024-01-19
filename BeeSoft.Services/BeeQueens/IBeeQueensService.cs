namespace BeeSoft.Services.BeeQueens;

using BeeSoft.Services.BeeQueens.Models;

public interface IBeeQueensService
{
    Task<ICollection<BeeQueenServiceModel>> GetBeeQueensAsync();

    Task<BeeQueenServiceModel?> GetByIdAsync(int id);

    Task<int> CreateAsync(BeeQueenServiceModel model);

    Task UpdateAsync(BeeQueenServiceModel model);

    Task<bool> DeleteAsync(int id);
}
