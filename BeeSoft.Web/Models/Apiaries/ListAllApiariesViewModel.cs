namespace BeeSoft.Web.Models.Apiaries;

using BeeSoft.Services.Apiaries.Models;

public sealed record ListAllApiariesViewModel : PagingViewModel
{
    public ListAllApiariesViewModel()
    {
        this.Apiaries = new HashSet<ApiaryServiceModel>();
    }
    public IEnumerable<ApiaryServiceModel> Apiaries { get; init; }
}
