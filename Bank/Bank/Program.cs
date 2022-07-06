using AutoMapper;
using Bank.BLL.DI;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddBusinessLogic(configuration);

builder.Services.AddAutoMapper(typeof(Bank.Mappers.Mapper), typeof(Bank.BLL.AMapper.Mapper));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();