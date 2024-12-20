﻿namespace NTT.CafeManagement.Application.Commands.Employee;

public record UpdateEmployeeCommand(UpdateEmployeeRequestDto Employee) : CommandRequest;

public class UpdateEmployeeCommandHandler(ICafeManagementDbContext dbContext) : BaseCommandHandler<UpdateEmployeeCommand>
{
    private Domain.Models.Employee _employee;
    private readonly ICafeManagementDbContext _dbContext = dbContext;


    protected async override Task<Response> DoHandle()
    {
        _employee.SetName(Command.Employee.Name)
            .SetEmail(Command.Employee.Email)
            .SetPhoneNumber(Command.Employee.PhoneNumber)
            .SetGender(Command.Employee.Gender);

        if (Command.Employee.CafeId.HasValue)
        {
            if (_employee.EmployeeCafeAssignments.Any())
            {
                _employee.EmployeeCafeAssignments
                    .Where(e => e.CafeId != Command.Employee.CafeId.Value)
                    .ToList()
                    .ForEach(x => _dbContext.RemoveEntity(x));
            }
        }

        if (Command.Employee.CafeId.HasValue && 
            !_employee.EmployeeCafeAssignments.Any(e => e.CafeId == Command.Employee.CafeId.Value))
            _employee.AddCafeAssignment(Command.Employee.CafeId.Value);

        await _dbContext.SaveChangesAsync();

        return Response.Ok();
    }

    protected async override Task Validate(ValidationContext validationContext)
    {
        _employee = await _dbContext.DbSet<Domain.Models.Employee>()
            .Include(e => e.EmployeeCafeAssignments)
            .ThenInclude(e => e.Cafe)
            .FirstOrDefaultAsync(x => x.Id == Command.Employee.Id);

        if (_employee == null)
        {
            validationContext.AddError("Employee not found.");
        }
    }
}