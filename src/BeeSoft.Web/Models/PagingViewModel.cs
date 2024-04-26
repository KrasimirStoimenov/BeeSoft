namespace BeeSoft.Web.Models;

public abstract record PagingViewModel
{
    public int PageNumber { get; set; }

    public bool HasPreviousPage => PageNumber > 1;

    public int PreviousPageNumber => PageNumber - 1;

    public bool HasNextPage => PageNumber < PagesCount;

    public int NextPageNumber => PageNumber + 1;

    public int PagesCount => (int)Math.Ceiling((double)Count / ItemsPerPage);

    public int Count { get; set; }

    public int ItemsPerPage { get; set; }
}
