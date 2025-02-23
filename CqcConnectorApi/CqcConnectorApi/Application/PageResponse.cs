namespace CqcConnectorApi.Application;

public class PageResponse
{    
    public int Total { get; set; }
    public string? FirstPageUri { get; set; }
    public int Page { get; set; }
    public string? PreviousPageUri { get; set; }
    public string? LastPageUri { get; set; }
    public string? NextPageUri { get; set; }
    public int PerPage { get; set; }
    public int TotalPages { get; set; }    
}
