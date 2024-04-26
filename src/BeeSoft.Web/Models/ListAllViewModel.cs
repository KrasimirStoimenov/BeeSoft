namespace BeeSoft.Web.Models;

public sealed record ListAllViewModel<T> : PagingViewModel
{
    public ListAllViewModel()
    {
        this.Items = new HashSet<T>();
    }
    public IEnumerable<T> Items { get; init; }
}
