namespace NTT.CafeManagement.Application.Queries.Cafe;

public record GetCafeByIdQuery(Guid CafeId) : IRequest<CafeListItemDto>;

public class GetCafeByIdQueryHandler(ICafeManagementDbContext dbContext) : IRequestHandler<GetCafeByIdQuery, CafeListItemDto>
{
    private readonly ICafeManagementDbContext _dbContext = dbContext;
    public async Task<CafeListItemDto> Handle(GetCafeByIdQuery request, CancellationToken cancellationToken)
    {
        var query = _dbContext.DbSet<Domain.Models.Cafe>()
                .AsNoTracking()
                .AsQueryable();
        query = query.Where(e => e.Id == request.CafeId);

        return await query
            .Select(x => new CafeListItemDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Location = x.Location,
                LogoUrl = x.LogoUrl
            })
            .FirstAsync(cancellationToken);
    }
}