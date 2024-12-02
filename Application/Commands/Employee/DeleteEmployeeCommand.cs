using NTT.CafeManagement.Application.Commands.Cafe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTT.CafeManagement.Application.Commands.Employee;

public record DeleteEmployeeCommand(Guid EmployeeId) : CommandRequest;

public class DeleteEmployeeCommandHandler : BaseCommandHandler<DeleteEmployeeCommand>
{
    protected override Task<Response> DoHandle()
    {
        throw new NotImplementedException();
    }

    protected override Task Validate(ValidationContext validationContext)
    {
        throw new NotImplementedException();
    }
}