namespace NTT.CafeManagement.Controllers;

[ApiController]
public class BaseController : ControllerBase
{
    protected IMediator Mediator { get; }

    protected BaseController(IMediator mediator)
    {
        Mediator = mediator;
    }

    protected IActionResult ActionResult(IResponse response) => response.Success ? Ok() : CreateBadRequestResult(response);

    protected IActionResult ActionResult<T>(T result) where T : class => result == null ? NotFound() : Ok(result);

    private IActionResult CreateBadRequestResult(IResponse response)
    {
        throw new ValidationException("Validation exception", response.ValidationResults);
    }
}
