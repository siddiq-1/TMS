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
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.UseMiddleware<FluentValidationMiddleware<RoleDto>>();
app.UseMiddleware<FluentValidationMiddleware<TaskAssignmentDto>>();
app.UseMiddleware<FluentValidationMiddleware<TaskCategoryDto>>();
app.UseMiddleware<FluentValidationMiddleware<TaskDto>>();
app.UseMiddleware<FluentValidationMiddleware<TaskInfoData>>();
app.UseMiddleware<FluentValidationMiddleware<TaskStatusMasterDto>>();
app.UseMiddleware<FluentValidationMiddleware<UserDto>>();
app.UseMiddleware<FluentValidationMiddleware<UserManagerMappingDto>>();
app.UseMiddleware<FluentValidationMiddleware<UserRoleMappingDto>>();
app.UseMiddleware<FluentValidationMiddleware<LoginDto>>();
app.UseMiddleware<FluentValidationMiddleware<RecurringJobDto>>();
app.UseMiddleware<FluentValidationMiddleware<ReportTypeMasterDto>>();
app.UseMiddleware<FluentValidationMiddleware<ScheduleReportDto>>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
