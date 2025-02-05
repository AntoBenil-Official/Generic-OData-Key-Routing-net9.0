using GenericControllerTest.Controllers;
using GenericControllerTest.MesDbContext;
using GenericControllerTest.Middleware.Routing;
using Microsoft.AspNetCore.OData;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using West.Manufacturing.Common.Util;
using West.Manufacturing.Repository.Implementations;
using West.Manufacturing.Repository.Interfaces;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddScoped<DbContext, MfgSystemsDbContext>();

        SqlConnectionStringBuilder dbBuilder = new SqlConnectionStringBuilder
        {
            ConnectionString = builder.Configuration.GetConnectionString("MFGSYSDB")
        };
        dbBuilder["Password"] = Cryptography.Decrypt(dbBuilder["Password"] as string);
        string sqlConnString = dbBuilder.ConnectionString;

        builder.Services.AddDbContext<MfgSystemsDbContext>(
                   options => options.UseSqlServer(dbBuilder.ConnectionString,
                   opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds)));


        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        builder.Logging.AddConsole();


        builder.Services.AddControllers()
            .AddOData(opt =>
            {
                opt.Select().Expand().Filter().OrderBy().Count().SetMaxTop(100)
                .AddRouteComponents("odata", ODataEDMBuilder.GetEdmModel());
            });

        builder.Services.AddMvc(opt =>
        {
            opt.Conventions.Add(new GenericControllerNameAttribute());
        })
        .ConfigureApplicationPartManager(apm =>
        {
            apm.FeatureProviders.Add(new GenericTypeControllerFeatureProvider());
        });

        // 🔹 Add Swagger service
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "My API",
                Version = "v1",
                Description = "An API for managing manufacturing data",
                Contact = new OpenApiContact
                {
                    Name = "Your Name",
                    Email = "your.email@example.com",
                    Url = new Uri("https://yourwebsite.com")
                }
            });
        });


        builder.Services.AddScoped(typeof(IEnterpriseRepository<>), typeof(EnterpriseSqlServerRepository<>));


        var app = builder.Build();
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = ""; // Access Swagger UI from the root (http://localhost:5000/)
            });
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.UseRouting();
        app.UseODataRouteDebug();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
        //app.MapControllers();

        app.Run();
    }
}