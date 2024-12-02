
namespace NTT.CafeManagement.Application.Commands.Employee;

public record UpdateEmployeeCommand(CreateOrUpdateEmployeeRequestDto Request) : CommandRequest;

public class UpdateEmployeeCommandHandler : BaseCommandHandler<UpdateEmployeeCommand>
{
    private Domain.Models.Employee _employee;

    protected async override Task<Response> DoHandle()
    {
        _employee.SetName(Command.Request.Name)
            .SetEmail(Command.Request.Email)
            .SetPhoneNumber(Command.Request.PhoneNumber)
            .SetGender(Command.Request.Gender);

        await CafeManagementDbContext.SaveChangesAsync();

        return Response.Ok();
    }

    protected async override Task Validate(ValidationContext validationContext)
    {
        _employee = await CafeManagementDbContext.DbSet<Domain.Models.Employee>().FirstOrDefaultAsync(x => x.Id == Command.Request.Id);

        if (_employee == null)
        {
            validationContext.AddError("Employee not found.");
        }
    }
}