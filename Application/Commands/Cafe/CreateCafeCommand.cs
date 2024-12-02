namespace NTT.CafeManagement.Application.Commands.Cafe;

public record CreateCafeCommand(CreateOrUpdateCafeRequestDto Request) : CommandRequest;

public class CreateCafeCommandHandler : BaseCommandHandler<CreateCafeCommand>
{
    protected async override Task<Response> DoHandle()
    {
        var newCafe = Domain.Models.Cafe.CreateNewCafe(Command.Request.Name)
            .SetDescription(Command.Request.Description)
            .SetLocation(Command.Request.Location)
            .SetLogoUrl(Command.Request.LogoUrl);

        await CafeManagementDbContext.AddEntityAsync(newCafe);

        await CafeManagementDbContext.SaveChangesAsync();

        return Response.Ok();
    }

    protected async override Task Validate(ValidationContext validationContext)
    {
        var cafeNameExists = await CafeManagementDbContext.DbSet<Domain.Models.Cafe>().AnyAsync(x => x.Name.ToLower() == Command.Request.Name.ToLower());
        if (cafeNameExists)
        {
            validationContext.AddError("This cafe name already exists.");
        }
    }
}