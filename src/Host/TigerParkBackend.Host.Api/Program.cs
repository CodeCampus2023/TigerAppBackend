using AutoMapper;
using TigerParkBackend.Host.Api;
using TigerParkBackend.Infrastructure.MapProfiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IMapper>(new Mapper(GetMapperConfiguration()));

builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddDbContextWithConfigurations();
builder.Services.AddJwtAuthenticationWithOptions(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();

static MapperConfiguration GetMapperConfiguration()
{
    var config = new MapperConfiguration(cfg =>
    {
        cfg.AddProfile<PartnerProfile>();
    });
    config.AssertConfigurationIsValid();
    return config;
}