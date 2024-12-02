namespace NTT.CafeManagement.Application.Extensions
{
    public static class DbMigrationExtensions
    {
        public static IApplicationBuilder MigrateDbContext<TContext>(this IApplicationBuilder appBuilder, Action<TContext, IServiceProvider> seeder) where TContext : DbContext
        {
            using var scope = appBuilder.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetService<TContext>();

            try
            {
                InvokeSeeder(seeder, context, services);
            }
            catch (Exception ex)
            {
                throw;
            }

            return appBuilder;
        }

        private static void InvokeSeeder<TContext>(Action<TContext, IServiceProvider> seeder, TContext context, IServiceProvider services)
            where TContext : DbContext
        {
            seeder(context, services);
        }
    }
}
