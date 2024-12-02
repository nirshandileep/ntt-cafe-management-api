using NTT.CafeManagement.Infrastructure.Database;

namespace NTT.CafeManagement.Application.Commands.Employee;

public record DeleteEmployeeCommand(Guid EmployeeId) : CommandRequest;

public class DeleteEmployeeCommandHandler(ICafeManagementDbContext dbContext) : BaseCommandHandler<DeleteEmployeeCommand>
{
    private readonly ICafeManagementDbContext _dbContext = dbContext;
    private Domain.Models.Employee _employee;

    protected async override Task<Response> DoHandle()
    {
        _dbContext.RemoveEntity(_employee);

        await _dbContext.SaveChangesAsync();

        return Response.Ok();
    }

    protected async override Task Validate(ValidationContext validationContext)
    {
        _employee = await _dbContext.DbSet<Domain.Models.Employee>()
               .Include(b => b.EmployeeCafeAssignments)
               .SingleOrDefaultAsync(s => s.Id == Command.EmployeeId);

        if (_employee == null)
        {
            validationContext.AddError("Employee with the given Id is not found.");
            return;
        }
    }
}