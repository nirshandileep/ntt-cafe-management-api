namespace NTT.CafeManagement.Infrastructure.Dtos
{
    public class CafeListItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Employees { get; set; }
        public string Location { get; set; }
        public string LogoUrl { get; set; }
    }
}
