namespace NTT.CafeManagement.Controllers
{
    [Route("api/[controller]s")]
    public class CafeController(IMediator mediator) : BaseController(mediator)
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateOrUpdateCafeRequestDto cafeRequest)
        {
            return ActionResult(await Mediator.Send(new CreateCafeCommand(cafeRequest)));
        }

        [HttpPut]
        public async Task<IActionResult> Update(CreateOrUpdateCafeRequestDto cafeRequest)
        {
            return ActionResult(await Mediator.Send(new CreateCafeCommand(cafeRequest)));
        }

        [HttpDelete("{cafeId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid cafeId)
        {
            return ActionResult(await Mediator.Send(new DeleteCafeCommand(cafeId)));
        }

        [HttpGet]
        public async Task<IActionResult> GetBeamConfigFilesByOrgSatelliteAndVsatProvider([FromQuery] string? location)
        {
            return ActionResult(await Mediator.Send(new SearchCafesQuery(location)));
        }
    }
}
