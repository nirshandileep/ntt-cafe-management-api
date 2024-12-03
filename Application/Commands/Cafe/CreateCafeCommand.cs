namespace NTT.CafeManagement.Application.Commands.Cafe;

public record CreateCafeCommand(CreateCafeRequestDto Request) : CommandRequest;

public class CreateCafeCommandHandler(ICafeManagementDbContext dbContext) : BaseCommandHandler<CreateCafeCommand>
{
    private readonly ICafeManagementDbContext _dbContext = dbContext;

    protected async override Task<Response> DoHandle()
    {
        var newCafe = Domain.Models.Cafe.CreateNewCafe(Command.Request.Name)
            .SetDescription(Command.Request.Description)
            .SetLocation(Command.Request.Location)
            .SetLogoUrl(Command.Request.LogoUrl);

        await _dbContext.AddEntityAsync(newCafe);

        await _dbContext.SaveChangesAsync();

        return Response.Ok();
    }

    protected async override Task Validate(ValidationContext validationContext)
    {
        var cafeNameExists = await _dbContext.DbSet<Domain.Models.Cafe>().AnyAsync(x => x.Name.ToLower() == Command.Request.Name.ToLower());
        if (cafeNameExists)
        {
            validationContext.AddError("This cafe name already exists.");
        }
    }
}