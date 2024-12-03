using NTT.CafeManagement.Infrastructure.Database;

namespace NTT.CafeManagement.Application.Commands.Cafe
{
    public record DeleteCafeCommand(Guid CafeId) : CommandRequest;

    public class DeleteCafeCommandHandler(ICafeManagementDbContext dbContext) : BaseCommandHandler<DeleteCafeCommand>
    {
        private readonly ICafeManagementDbContext _dbContext = dbContext;
        private Domain.Models.Cafe _cafe;

        protected override async Task Validate(ValidationContext validationContext)
        {
            _cafe = await _dbContext.DbSet<Domain.Models.Cafe>()
                .Include(b => b.EmployeeCafeAssignments)
                .SingleOrDefaultAsync(s => s.Id == Command.CafeId);

            if (_cafe == null)
            {
                validationContext.AddError("Cafe with the given Id is not found.");
                return;
            }
        }

        protected override async Task<Response> DoHandle()
        {
            //if (_cafe.EmployeeCafeAssignments.Any())
            //{
            //    _cafe.EmployeeCafeAssignments.ForEach(x => _dbContext.RemoveEntity(x));
            //}

            _dbContext.RemoveEntity(_cafe);

            await _dbContext.SaveChangesAsync();

            return Response.Ok();
        }
    }

}
