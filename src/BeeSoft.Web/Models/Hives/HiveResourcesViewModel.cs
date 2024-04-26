namespace BeeSoft.Web.Models.Hives;

public sealed record HiveResourcesViewModel<T>
{
    public HiveResourcesViewModel()
    {
        this.Resources = new HashSet<T>();
    }

    public int HiveNumber { get; init; }

    public IEnumerable<T> Resources { get; init; }
}
