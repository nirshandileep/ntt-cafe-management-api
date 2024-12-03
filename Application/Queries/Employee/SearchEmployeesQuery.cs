namespace NTT.CafeManagement.Application.Queries.Employee;

public record SearchEmployeesQuery(string CafeName) : IRequest<List<EmployeeListItemDto>>;

public class SearchEmployeesQueryHandler(ICafeManagementDbContext dbContext) : IRequestHandler<SearchEmployeesQuery, List<EmployeeListItemDto>>
{
    private readonly ICafeManagementDbContext _dbContext = dbContext;

    public async Task<List<EmployeeListItemDto>> Handle(SearchEmployeesQuery request, CancellationToken cancellationToken)
    {
        var query = _dbContext.DbSet<Domain.Models.Employee>()
                     .Include(e => e.EmployeeCafeAssignments)
                        .ThenInclude(a => a.Cafe)
                    .AsNoTracking()
                    .AsQueryable();

        if (!string.IsNullOrWhiteSpace(request.CafeName))
        {
            query = query.Where(e =>
                e.EmployeeCafeAssignments.Any(a => a.Cafe.Name.ToLower() == request.CafeName.ToLower()));
        }

        var result = await query
            .Select(x => new EmployeeListItemDto
            {
                Id = x.EmployeeCode,
                Name = x.Name,
                Email_Address = x.Email,
                Phone_Number = x.PhoneNumber,
                Days_Worked = (x.EmployeeCafeAssignments == null || x.EmployeeCafeAssignments.Any()) ?
                    (int)(DateTime.UtcNow - x.EmployeeCafeAssignments.First().StartDate).TotalDays : 0,
                Cafe = x.EmployeeCafeAssignments.Any() ? x.EmployeeCafeAssignments.First().Cafe.Name : ""

            })
            .ToListAsync(cancellationToken);

        return result.OrderByDescending(e => e.Days_Worked).ToList();
    }
}