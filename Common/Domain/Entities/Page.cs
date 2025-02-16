namespace E_Learn.Common.Domain;

public class Page<T>
{

    public IReadOnlyList<T> content { get; }

    public Meta meta { get; }

    public Page(IEnumerable<T> content, int total, int page, int perPage)
    {
        this.content = content.ToList().AsReadOnly();
        this.meta = new Meta(total, page, perPage);
    }
}

public class Meta
{

    public int total { get; }
    public int page { get; }
    public int perPage { get; }
    public int total_pages => (int)Math.Ceiling((double)total / perPage);
    public bool HasNextPage => page < total_pages;
    public bool HasPreviousPage => page > 1;

    public Meta(int total, int page, int perPage)
    {
        this.total = total;
        this.page = page;
        this.perPage = perPage;
    }
}