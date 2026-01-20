using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using LibraryProject.Business.Abstract;
using LibraryProject.Business.AutoMapper;
using LibraryProject.Business.Concrete;
using LibraryProject.Business.ValidationRules;
using LibraryProject.DataAccess.Abstract;
using LibraryProject.DataAccess.Concrete.EntityFramework;
using LibraryProject.DataAccess.Extension;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<BookAddValidator>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDataAccessServices(builder.Configuration);


var app = builder.Build();
app.UseMiddleware<LibraryProject.API.Middlewares.GlobalExceptionMiddleware>();  //middleware ekleme

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
