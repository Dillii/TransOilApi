using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using TransOilApi.DataBase;
using TransOilApi.DataBase.Interfaces;
using TransOilApi.Services.Classes;
using TransOilApi.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<TransOilContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
var options = new DbContextOptionsBuilder<TransOilContext>()
    .UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
    .Options;
using (var context = new TransOilContext(options))
    context.Database.Migrate();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IOrganizationsContext, TransOilContext>();
builder.Services.AddScoped<IConsumptionObjectContext, TransOilContext>();
builder.Services.AddScoped<IElectricitySupplyPointsContext, TransOilContext>();
builder.Services.AddScoped<IElectricityMeasurementPointContext, TransOilContext>();
builder.Services.AddScoped<ITransformatorsContext, TransOilContext>();
builder.Services.AddScoped<IElectricEnergyMeterContext, TransOilContext>();

builder.Services.AddScoped<IConsumptionObjectService, ConsumptionObjectService>();
builder.Services.AddScoped<IElectricityMeasurmentPointService, ElectricityMeasurmentPointService>();
builder.Services.AddScoped<IOrganisationsService, OrganisationsSerivce>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
