using Finance.B4.Application.Handlers.Quotes.GetListQuotesRandom;
using Finance.B4.Application.Services;
using Finance.B4.Domain.Interfaces.Services;
using Finance.B4.Infra.Http;
using Finance.B4.Infra.Seed;
using Refit;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(
    config => config.RegisterServicesFromAssemblyContaining<GetListQuotesRandomHandler>()
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services
    .AddRefitClient<IYahooClient>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://query2.finance.yahoo.com/v8/finance/chart"));


builder.Services.AddTransient<IRabbitMQService, RabbitMQService>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
   app.UseSwagger();
   app.UseSwaggerUI();
//}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

var baseUrl = Environment.GetEnvironmentVariable("BASE_URL") ?? builder.Configuration.GetSection("FinanceApiLocal:BaseUrl").Value;
SeedEvent.Seed(app, baseUrl);

app.Run();
