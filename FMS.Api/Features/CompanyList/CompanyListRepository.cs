namespace FMS.Api.Features.CompanyList;

public class CompanyListRepository
{
    private List<CompanyListItemModel> _companies { get; set; } = new List<CompanyListItemModel>(
        new[]
        {
            new CompanyListItemModel("Paide Kaubamaja", "Eesti", "Paide"),
            new CompanyListItemModel("Türi Kaubamaja", "Eesti", "Türi"),
            new CompanyListItemModel("Rapla Kaubamaja", "Eesti", "Rapla"),
            new CompanyListItemModel("Pärnu Kaubamajakas", "Eesti", "Pärnu"),
            new CompanyListItemModel("Vana-Viru Ehtepood", "Eesti", "Tallinn"),
            new CompanyListItemModel("Võru TÜ", "Eesti", "Võru"),
            new CompanyListItemModel("Saaremaa TÜ", "Eesti", "Kuressaare"),
            new CompanyListItemModel("Peetri Kullaäri", "Eesti", "Viljandi"),
            new CompanyListItemModel("Põlva Ehtemaailm", "Eesti", "Põlva"),
            new CompanyListItemModel("Ilumaailm", "Eesti", "Tallinn"),
            new CompanyListItemModel("Ehtekaubamaja", "Eesti", "Tartu"),
            new CompanyListItemModel("Kullast süda", "Eesti", "Rakvere"),
        });

    public CompanyListModel GetPagedList(string? searchString, int page, int pageSize)
    {
        var query = _companies.AsEnumerable();

        if (searchString is not null)
        {
            query = query
                .Where(c => c.CompanyName.Contains(searchString, StringComparison.OrdinalIgnoreCase));
        }

        int pageCount = (int)Math.Ceiling((decimal)query.Count() / pageSize);

        query = query
            .Skip((page - 1) * pageSize)
            .Take(pageSize);

        return new CompanyListModel { PagedList = query.ToList(), PageCount = pageCount };
    }
}
