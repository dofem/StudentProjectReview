using Microsoft.EntityFrameworkCore;
using ProjectApprovalWorkflow.Data;
using ProjectApprovalWorkflow.Service.Implementation;
using ProjectApprovalWorkflow.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ISupervisorService, SupervisorService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IHODService, HODService>();
builder.Services.AddScoped<IProjectService, ProjectService>();

builder.Services.AddDbContext<ApplicationDbContext>(Options =>
{ Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); }
);

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
