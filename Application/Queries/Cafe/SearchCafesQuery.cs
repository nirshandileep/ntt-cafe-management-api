using MediatR;
using NTT.CafeManagement.Infrastructure.Database;

namespace NTT.CafeManagement.Application.Queries.Cafe;

public record SearchCafesQuery(string Location) : IRequest<List<CafeListItemDto>>;

public class SearchCafesQueryHandler(ICafeManagementDbContext dbContext) : IRequestHandler<SearchCafesQuery, List<CafeListItemDto>>
{
    private readonly ICafeManagementDbContext _dbContext = dbContext;

    public async Task<List<CafeListItemDto>> Handle(SearchCafesQuery request, CancellationToken cancellationToken)
    {
        var query = _dbContext.DbSet<Domain.Models.Cafe>()
                .AsNoTracking()
                .AsQueryable();

        if (!string.IsNullOrWhiteSpace(request.Location))
        {
            query = query.Where(e => e.Location.ToLower().Contains(request.Location.ToLower()));
        }

        return await query
            .Select(x => new CafeListItemDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Employees = x.EmployeeCafeAssignments.Count,
                Location = x.Location,
                LogoUrl = x.LogoUrl
            })
            .OrderByDescending(x => x.Employees)
            .ToListAsync(cancellationToken);
    }
}