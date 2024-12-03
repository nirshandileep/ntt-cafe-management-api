namespace NTT.CafeManagement.Controllers;

[Route("api/[controller]s")]
public class EmployeeController(IMediator mediator) : BaseController(mediator)
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateEmployeeRequestDto employee)
    {
        return ActionResult(await Mediator.Send(new CreateEmployeeCommand(employee)));
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateEmployeeRequestDto employee)
    {
        return ActionResult(await Mediator.Send(new UpdateEmployeeCommand(employee)));
    }

    [HttpDelete("{employeeId}")]
    public async Task<IActionResult> Delete([FromRoute] string employeeId)
    {
        return ActionResult(await Mediator.Send(new DeleteEmployeeCommand(employeeId)));
    }

    [HttpGet("{employeeId}")]
    public async Task<IActionResult> GetById([FromRoute] string employeeId)
    {
        return ActionResult(await Mediator.Send(new GetEmployeeByIdQuery(employeeId)));
    }

    [HttpGet]
    public async Task<IActionResult> SearchByCafe([FromQuery] Guid? cafe)
    {
        return ActionResult(await Mediator.Send(new SearchEmployeesQuery(cafe)));
    }
}
