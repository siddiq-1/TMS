using Hangfire;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using TMS.API.Infrastructure.Extension;
using TMS.API.Infrastructure.Middleware;
using TMS.Data.MODEL;
using TMS.ModelDTO;
using TMS.ModelDTO.Task;
using TMS.ModelDTO.User;

var builder = WebApplication.CreateBuilder(args);

// AddAsync services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.InstallAssemblyService(builder.Configuration);
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<TokenBlacklistMiddleware>();
app.UseMiddleware<ExceptionMiddleware>();
app.UseHangfireDashboard();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
