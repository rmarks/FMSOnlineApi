namespace FMS.Api.Features.CompanyList;

public class CompanyListModel
{
    public IEnumerable<CompanyListItemModel> PagedList { get; set; } = default!;
    public int PageCount { get; set; }
}

public record CompanyListItemModel(string CompanyName, string Country, string City);
