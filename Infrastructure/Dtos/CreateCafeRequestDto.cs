namespace NTT.CafeManagement.Infrastructure.Dtos;

public class CreateCafeRequestDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public string? LogoUrl { get; set; }
}
