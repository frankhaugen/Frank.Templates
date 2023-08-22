using Frank.Templates.Microservice.Api.MappingProfiles;
using Frank.Templates.Microservice.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(x =>
{
    x.AddProfile<CompanyProfile>();
});
builder.Services.AddSwaggerGen(x =>
{
    x.IgnoreObsoleteActions();
    x.OrderActionsBy(y => y.RelativePath);
});

builder.Services.AddScoped<ICompanyService, CompanyService>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();