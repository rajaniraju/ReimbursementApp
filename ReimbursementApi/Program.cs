
using Microsoft.EntityFrameworkCore;
using ReimbursementApi.Data;
using ReimbursementApi.Models;
var builder = WebApplication.CreateBuilder(args);
// Load configuration from appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
// Register SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=reimbursements.db"));

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
// Register AppSettings from appsettings.json (for example, for API URL)
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // required
builder.Services.AddSwaggerGen();           // enable Swagger

var app = builder.Build();
app.UseCors("AllowAll");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Enable Swagger middleware
app.UseSwaggerUI(); // This will generate a UI at /swagger
}
app.MapControllers();


app.Run();

