using System.Text.Json.Serialization;
using DotNetBoilerplate.Api.Organizations;
using DotNetBoilerplate.Api.Devices;
using DotNetBoilerplate.Api.Employees;
using DotNetBoilerplate.Api.DeviceAssignment;
using DotNetBoilerplate.Api.Users;
using DotNetBoilerplate.Application;
using DotNetBoilerplate.Core;
using DotNetBoilerplate.Infrastructure;
using DotNetBoilerplate.Shared;
using DotNetBoilerplate.Api.Faults;
using DotNetBoilerplate.Api.DeviceCategories;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddShared()
    .AddApplication()
    .AddCore()
    .AddInfrastructure(builder.Configuration)
    .AddControllers()
    .AddJsonOptions(options => { options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });

var app = builder.Build();

app.MapUsersEndpoints();
app.MapOrganizationsEndpoints();
app.MapDevicesEndpoints();
app.MapEmployeesEndpoints();
app.MapFaultsEndpoints();
app.MapDeviceCategoriesEndpoints();
app.MapDeviceAssignmentsEndpoints();

app.UseInfrastructure();

await app.RunAsync();