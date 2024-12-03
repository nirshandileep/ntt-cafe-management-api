namespace NTT.CafeManagement.Application.Commands.Employee;

public record CreateEmployeeCommand(CreateEmployeeRequestDto Employee) : CommandRequest;

public class CreateEmployeeCommandHandler(ICafeManagementDbContext dbContext) : BaseCommandHandler<CreateEmployeeCommand>
{
    private readonly ICafeManagementDbContext _dbContext = dbContext;

    protected async override Task<Response> DoHandle()
    {
        var newEmployee = Domain.Models.Employee.Create(GenerateEmployeeCode())
            .SetName(Command.Employee.Name)
            .SetEmail(Command.Employee.Email)
            .SetPhoneNumber(Command.Employee.PhoneNumber)
            .SetGender(Command.Employee.Gender);

        if (Command.Employee.CafeId.HasValue)
            newEmployee.AddCafeAssignment(Command.Employee.CafeId.Value);

        await _dbContext.AddEntityAsync(newEmployee);

        await _dbContext.SaveChangesAsync();

        return Response.Ok();
    }

    private string GenerateEmployeeCode()
    {
        const string prefix = "UI";
        string randomCode = Guid.NewGuid().ToString("N").Substring(0, 7).ToUpper();
        return $"{prefix}{randomCode}";
    }

    protected async override Task Validate(ValidationContext validationContext)
    {
        var employeeExists = await _dbContext.DbSet<Domain.Models.Employee>()
            .AnyAsync(x => x.Email.ToLower() == Command.Employee.Email.ToLower());

        if (employeeExists)
        {
            validationContext.AddError($"Employee with email '{Command.Employee.Email}' already exists.");
        }
    }
}