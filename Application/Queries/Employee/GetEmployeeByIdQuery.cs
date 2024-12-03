namespace NTT.CafeManagement.Application.Queries.Employee;

public record GetEmployeeByIdQuery(string EmployeeId) : IRequest<EmployeeDto>;

public class GetEmployeeByIdQueryHandler(ICafeManagementDbContext dbContext) : IRequestHandler<GetEmployeeByIdQuery, EmployeeDto>
{
    private readonly ICafeManagementDbContext _dbContext = dbContext;

    public async Task<EmployeeDto> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        var query = _dbContext.DbSet<Domain.Models.Employee>()
                .AsNoTracking()
                .AsQueryable();

        query = query.Where(e => e.Id == request.EmployeeId);

        return await query
            .Select(x => new EmployeeDto
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                Cafe = x.EmployeeCafeAssignments.Any() ? x.EmployeeCafeAssignments.First().Cafe.Name : null,
                CafeId = x.EmployeeCafeAssignments.Any() ? x.EmployeeCafeAssignments.First().CafeId : null,
                Gender = x.Gender
            })
            .FirstAsync(cancellationToken);
    }
}
