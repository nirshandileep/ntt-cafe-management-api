namespace NTT.CafeManagement.Infrastructure.Core
{
    public class AppConfiguration : IAppConfiguration
    {
        public string DatabaseConnectionString { get; set; }
        public int DatabaseCommanTimeoutInSeconds { get; set; }
    }
}
