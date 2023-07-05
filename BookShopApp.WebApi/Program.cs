using BookShopApp.Application;
using BookShopApp.Application.Common.Mappings;
using BookShopApp.Application.Interfaces;
using BookShopApp.Persistence;
using BookShopApp.WebApi.Middleware;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(IDataContext).Assembly));
});

builder.Services.AddAplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});

builder.Services.AddSwaggerGen();
var app = builder.Build();

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<Seed>();
        service.SeedDataContext();
    }
}



if (app.Environment.IsDevelopment())
{
    SeedData(app);
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI(config =>
{
    config.RoutePrefix = string.Empty;
    config.SwaggerEndpoint("swagger/v1/swagger.json", "BookShopApp API");
});
app.UseCustomExceptionHandler();
app.UseRouting();

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.MapControllers();

app.Run();
