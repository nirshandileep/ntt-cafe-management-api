namespace NTT.CafeManagement.Application.Commands.Cafe;

public record UpdateCafeCommand(UpdateCafeRequestDto Request) : CommandRequest;

public class UpdateCafeCommandHandler(ICafeManagementDbContext dbContext) : BaseCommandHandler<UpdateCafeCommand>
{
    private readonly ICafeManagementDbContext _dbContext = dbContext;
    private Domain.Models.Cafe _cafe;

    protected async override Task<Response> DoHandle()
    {
        _cafe.SetDescription(Command.Request.Description)
            .SetLocation(Command.Request.Location)
            .SetLogoUrl(Command.Request.LogoUrl);

        await _dbContext.SaveChangesAsync();

        return Response.Ok();
    }

    protected async override Task Validate(ValidationContext validationContext)
    {
        _cafe = await _dbContext.DbSet<Domain.Models.Cafe>().FirstOrDefaultAsync(x => x.Id == Command.Request.Id);

        if (_cafe == null)
        {
            validationContext.AddError("Cafe not found.");
        }
    }
}