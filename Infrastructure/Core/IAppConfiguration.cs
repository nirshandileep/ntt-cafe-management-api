namespace NTT.CafeManagement.Infrastructure.Core
{
    public interface IAppConfiguration
    {
        string DatabaseConnectionString { get; set; }
        int DatabaseCommanTimeoutInSeconds { get; set; }
    }
}
