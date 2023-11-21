using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sample_Serializer.Middlewares;
using Sample_Serializer.Services;
using Sample_Serializer.Validator;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IJsonSerializer,NewtonsoftJSONSerializer>();
builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAllOrigins", builder =>
          {
             builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();

          });
    });
// builder.Services.AddScoped<StudentValidator>();
builder.Services.AddFluentValidation(options =>
{
    options.RegisterValidatorsFromAssemblyContaining<StudentValidator>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
 //app.UseMiddleware<Sample_Serializer.Middlewares.ExceptionHandlerMiddleware>();
         
         
         
app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
