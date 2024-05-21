using Desafio.HomeBrokerB4.Application.Consumer;
using Desafio.HomeBrokerB4.Application.Handlers.Queries.GetListQuotesRandom;
using Desafio.HomeBrokerB4.Infra.Context;
using Desafio.HomeBrokerB4.Infra.Ioc;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(
    config => config.RegisterServicesFromAssemblyContaining<GetListQuotesRandomQueryHandler>()
);

builder.Services.AddDbContext<HomeBrokerB4ContextDb>(opt => opt.UseInMemoryDatabase("HomeBrokerB4"));

builder.Services.AddServiceDependency();

//builder.Services.AddHostedService<Consumer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
