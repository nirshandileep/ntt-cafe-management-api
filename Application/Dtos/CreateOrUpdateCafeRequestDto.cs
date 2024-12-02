namespace NTT.CafeManagement.Application.Dtos
{
    public class CreateOrUpdateCafeRequestDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string? LogoUrl { get; set; }
    }
}
