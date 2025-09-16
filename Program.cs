using Microsoft.EntityFrameworkCore;
using StudyTracker.Context;
using StudyTracker.Interfaces;
using StudyTracker.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IStudyLogRepository, StudyLogRepository>();
builder.Services.AddScoped<IAudioOwnerRepository, AudioOwnerRepository>();
builder.Services.AddScoped<IAudioMessageRepository, AudioMessageRepository>();
builder.Services.AddSwaggerGen();

// DbContext (example with SQL Server)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<StudyContext>(options => 
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), 
        new MySqlServerVersion(new Version(8, 0, 29))));

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure middleware
if (!app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); 

app.UseRouting();

app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Study Tracker API");
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();