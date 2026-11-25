using Microsoft.Extensions.Options;
using MongoDB.Driver;
using StudentManagement.Data;
using StudentManagement.Service;
using StudentManagement.Service.impl;
using StudentManagement.Setting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection(nameof(MongoDbSettings)));
builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    return new MongoClient(settings.ConnectionString);
});
builder.Services.AddSingleton<MongoDbContext>();
builder.Services.AddScoped<DepartmentService, DepartmentServiceImpl>();
builder.Services.AddScoped<StudentService, StudentServiceImpl>();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(name: "department", pattern: "{controller=Department}/{action=Create}/{id?}");
app.MapControllerRoute(name: "student", pattern: "{controller=Student}/{action=Create}/{id?}");


app.Run();
