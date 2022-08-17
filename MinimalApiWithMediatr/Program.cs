using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MinimalApiWithMediatr.Common.Behaviours;
using MinimalApiWithMediatr.Common.Extensions;
using MinimalApiWithMediatr.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseInMemoryDatabase("Db"));
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddMediatR(x => x.AsScoped(), typeof(Program));
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger().UseSwaggerUI();
app.MapRoutes();

app.Run();
