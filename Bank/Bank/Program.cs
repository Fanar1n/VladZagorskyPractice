using System.Reflection;
using FluentValidation.AspNetCore;
using Bank.BLL.DI;
using Bank.Middleware;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddBusinessLogic(configuration);
builder.Services.AddAutoMapper(typeof(Bank.BLL.AMapper.Mapper), typeof(Bank.Mappers.Mapper));
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssembly(Assembly.Load("Bank")));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();