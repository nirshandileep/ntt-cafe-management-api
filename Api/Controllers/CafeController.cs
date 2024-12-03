using NTT.CafeManagement.Infrastructure.Dtos;

namespace NTT.CafeManagement.Controllers
{
    [Route("api/[controller]s")]
    public class CafeController(IMediator mediator) : BaseController(mediator)
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateCafeRequestDto cafeRequest)
        {
            return ActionResult(await Mediator.Send(new CreateCafeCommand(cafeRequest)));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCafeRequestDto cafeRequest)
        {
            return ActionResult(await Mediator.Send(new UpdateCafeCommand(cafeRequest)));
        }

        [HttpDelete("{cafeId}")]
        public async Task<IActionResult> Delete([FromRoute] string cafeId)
        {
            return ActionResult(await Mediator.Send(new DeleteCafeCommand(Guid.Parse(cafeId))));
        }

        [HttpGet("{cafeId}")]
        public async Task<IActionResult> GetById([FromRoute] Guid cafeId)
        {
            return ActionResult(await Mediator.Send(new GetCafeByIdQuery(cafeId)));
        }

        [HttpGet("location")]
        public async Task<IActionResult> SearchByLocation([FromQuery] string? location)
        {
            return ActionResult(await Mediator.Send(new SearchCafesQuery(location)));
        }
    }
}
