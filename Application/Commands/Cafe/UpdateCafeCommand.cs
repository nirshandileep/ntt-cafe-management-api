namespace NTT.CafeManagement.Application.Commands.Cafe;

public record UpdateCafeCommand(CreateOrUpdateCafeRequestDto Request) : CommandRequest;

public class UpdateCafeCommandHandler : BaseCommandHandler<UpdateCafeCommand>
{
    private Domain.Models.Cafe _cafe;

    protected async override Task<Response> DoHandle()
    {
        _cafe.SetDescription(Command.Request.Description)
            .SetLocation(Command.Request.Location)
            .SetLogoUrl(Command.Request.LogoUrl);

        await CafeManagementDbContext.SaveChangesAsync();

        return Response.Ok();
    }

    protected async override Task Validate(ValidationContext validationContext)
    {
        _cafe = await CafeManagementDbContext.DbSet<Domain.Models.Cafe>().FirstOrDefaultAsync(x => x.Id == Command.Request.Id);

        if (_cafe == null)
        {
            validationContext.AddError("Cafe not found.");
        }
    }
}