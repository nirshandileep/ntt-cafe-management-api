﻿using NTT.CafeManagement.Application.Commands.Employee;
using NTT.CafeManagement.Application.Queries.Employee;

namespace NTT.CafeManagement.Controllers;

[Route("api/[controller]s")]
public class EmployeeController(IMediator mediator) : BaseController(mediator)
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateOrUpdateEmployeeRequestDto employee)
    {
        return ActionResult(await Mediator.Send(new CreateEmployeeCommand(employee)));
    }

    [HttpPut]
    public async Task<IActionResult> Update(CreateOrUpdateEmployeeRequestDto employee)
    {
        return ActionResult(await Mediator.Send(new UpdateEmployeeCommand(employee)));
    }

    [HttpDelete("{employeeId}")]
    public async Task<IActionResult> Delete([FromRoute] Guid employeeId)
    {
        return ActionResult(await Mediator.Send(new DeleteEmployeeCommand(employeeId)));
    }

    [HttpGet]
    public async Task<IActionResult> GetBeamConfigFilesByOrgSatelliteAndVsatProvider([FromQuery] string? cafe)
    {
        return ActionResult(await Mediator.Send(new SearchEmployeesQuery(cafe)));
    }
}
