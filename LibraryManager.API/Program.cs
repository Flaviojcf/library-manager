using FluentValidation;
using FluentValidation.AspNetCore;
using LibraryManager.API.Filter;
using LibraryManager.Application.Commands.CreateBook;
using LibraryManager.Application.Commands.UpdateBook;
using LibraryManager.Application.Validators;
using LibraryManager.Domain.Repositories;
using LiBraryManager.Infrastructure.Persistance;
using LiBraryManager.Infrastructure.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter))).AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateBookCommandValidator>());
builder.Services.AddScoped<IValidator<CreateBookCommand>, CreateBookCommandValidator>();
builder.Services.AddScoped<IValidator<UpdateBookCommand>, UpdateBookCommandValidator>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<LibraryManagerDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IBookRepository, BookRepository>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateBookCommand).Assembly));

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
