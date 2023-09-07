using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CollegeEf.Data;
using CollegeEf.Services;
using Mapster;
using CollegeEf.Models;
using CollegeApi.ModelDtos;
using CollegeApi.ServiceInterfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CollegeEfContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CollegeEfContext") ?? throw new InvalidOperationException("Connection string 'CollegeEfContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IStudentService, StudentServices>();
builder.Services.AddScoped<ICourseService, CourseServices>();
builder.Services.AddScoped<IFacultyService, FacultyServices>();
builder.Services.AddScoped<IDepartmentService, DepartmentServices>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
Concat();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void Concat()
{
    TypeAdapterConfig<Students, StudentsDto>.NewConfig().Map(dest => dest.Guardian, src => src.Fathername + "" + src.MotherName);
    TypeAdapterConfig<StudentsDto, Students>.NewConfig().Map(dest => dest.Fathername, src => src.Guardian);
}
