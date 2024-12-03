namespace NTT.CafeManagement.IoC;

public static class WebApplicationBuilderExtensions
{
    public static void AddConfigurations(this WebApplicationBuilder builder)
    {
        builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
    }
}
