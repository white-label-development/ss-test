namespace CqcConnectorApi.Application;

public class PageRequest(int page, int perPage)
{
    public int Page { get; init; } = page;
    public int PerPage { get; init; } = perPage;

    public override string ToString() => $"page={Page}&perPage={PerPage}";    
}
