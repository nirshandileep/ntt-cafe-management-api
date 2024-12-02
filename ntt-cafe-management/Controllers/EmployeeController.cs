using NTT.CafeManagement.Application.Commands.Employee;

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

    [HttpDelete("{cafeId}")]
    public async Task<IActionResult> Delete([FromRoute] Guid cafeId)
    {
        return ActionResult(await Mediator.Send(new DeleteEmployeeCommand(cafeId)));
    }

    [HttpGet("location/{location}")]
    public async Task<IActionResult> GetBeamConfigFilesByOrgSatelliteAndVsatProvider([FromRoute] string location)
    {
        return ActionResult(await Mediator.Send(new SearchCafesQuery(location)));
    }
}
