namespace NTT.CafeManagement.Application.Commands.Employee;

public record CreateEmployeeCommand(CreateOrUpdateEmployeeRequestDto Employee) : CommandRequest;

public class CreateEmployeeCommandHandler : BaseCommandHandler<CreateEmployeeCommand>
{
    protected async override Task<Response> DoHandle()
    {
        var newEmployee = Domain.Models.Employee.Create(EmployeeCode())
            .SetName(Command.Employee.Name)
            .SetEmail(Command.Employee.Email)
            .SetPhoneNumber(Command.Employee.PhoneNumber)
            .SetGender(Command.Employee.Gender);

        await CafeManagementDbContext.AddEntityAsync(newEmployee);

        await CafeManagementDbContext.SaveChangesAsync();

        return Response.Ok();
    }

    private string EmployeeCode()
    {
        throw new NotImplementedException();
    }

    protected async override Task Validate(ValidationContext validationContext)
    {
        var employeeExists = await CafeManagementDbContext.DbSet<Domain.Models.Employee>()
            .AnyAsync(x => x.Email.ToLower() == Command.Employee.Email.ToLower());

        if (employeeExists)
        {
            validationContext.AddError($"Employee with email '{Command.Employee.Email}' already exists.");
        }
    }
}