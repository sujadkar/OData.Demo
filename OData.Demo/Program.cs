using Dapper.Builder.Core;
using Dapper.Builder;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using OData.Demo.Data;
using OData.Demo.Data.Entities;
using System;
using Snowflake.Data.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.SqlClient;
using Dapper.Builder.Services;
using Microsoft.AspNetCore.Http.Extensions;

static IEdmModel GetEdmModel()
{
    ODataConventionModelBuilder modelBuilder = new ODataConventionModelBuilder();
    modelBuilder.EntitySet<Gadgets>("GadgetsOdata");
    return modelBuilder.GetEdmModel();
}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllers().AddOData(options => options.Select().Filter().Count().OrderBy().AddRouteComponents("odata",GetEdmModel()));

var connectionString = builder.Configuration.GetConnectionString("MyWorldDbConnection");

var snowFlakeconnectionString = builder.Configuration.GetConnectionString("SnowFlake");

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddDapperBuilder(
//       new CoreBuilderConfiguration
//       {
//           DatabaseType = DatabaseType.SQL,
//           DbConnectionFactory = (ser) => new SqlConnection(connectionString)
//       });

SnowflakeDbConnection snowflakeDbConnection =  new SnowflakeDbConnection();
snowflakeDbConnection.ConnectionString = snowFlakeconnectionString;


builder.Services.AddDapperBuilder(
       new CoreBuilderConfiguration
       {
           DatabaseType = DatabaseType.Snowflake,
           DbConnectionFactory = (ser) => snowflakeDbConnection
       }); ;



builder.Services.AddScoped<IGadgetsRepository, GadgetsRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<MyWorldDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

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
