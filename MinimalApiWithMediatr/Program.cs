using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MinimalApiWithMediatr.Common.Behaviours;
using MinimalApiWithMediatr.Common.Extensions;
using MinimalApiWithMediatr.Data;
using MinimalApiWithMediatr.Todo.Queries.GetTodosQuery;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseInMemoryDatabase("Db"));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(x => x.AsScoped(), typeof(Program));
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
builder.Services.AddScoped<IRepository, Repository>();

var app = builder.Build();

app.MapRoutesFromAssembly(Assembly.GetExecutingAssembly());
//app.UseMapper();

app.Run();
