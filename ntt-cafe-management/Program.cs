using NTT.CafeManagement.Application.IoC;
using NTT.CafeManagement.Infrastructure.Database;
using NTT.CafeManagement.Infrastructure.IoC;
using NTT.CafeManagement.IoC;
using NTT.CafeManagement.Application.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddConfigurations();

var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CafeManagementDbContext>();

builder.Services.RegisterApi(configuration);
builder.Services.RegisterApplication();
builder.Services.RegisterInfrastructure(builder.Configuration);
builder.Services.AddProblemDetails();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MigrateDbContext<CafeManagementDbContext>((context, services) =>
{
    new CafeManagementDbContextSeed().SeedAsync(context).Wait();
});

app.Run();