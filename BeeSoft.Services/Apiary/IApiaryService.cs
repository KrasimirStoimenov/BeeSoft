namespace BeeSoft.Services.Apiary;
public interface IApiaryService
{
    Task GetApiaryByIdAsync(int id);

    Task<int> CreateAsync();

    Task EditAsync();

    Task<bool> DeleteAsync(int id);
}
