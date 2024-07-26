using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Para.Api.Middleware;
using Para.Api.Service;
using Para.Bussiness;
using Para.Bussiness.Command.Customer.CreateCustomer;
using Para.Bussiness.Validation.Customer;
using Para.Data.Context;
using Para.Data.Domain;
using Para.Data.UnitOfWork;
using System.Data;
using System.Text.Json.Serialization;

namespace Para.Api;

public class Startup
{
    public IConfiguration Configuration;

    public Startup(IConfiguration configuration)
    {
        this.Configuration = configuration;
    }


    public void ConfigureServices(IServiceCollection services)
    {

        services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.WriteIndented = true;
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });


        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Para.Api", Version = "v1" });
        });

        var connectionStringSql = Configuration.GetConnectionString("MsSqlConnection");
        services.AddDbContext<ParaDbContext>(options => options.UseSqlServer(connectionStringSql));
        services.AddScoped<IDbConnection>(sp => new SqlConnection(Configuration.GetConnectionString("MsSqlConnection")));

        //services.AddDbContext<ParaDbContext>(options => options.UseNpgsql(connectionStringPostgre));


        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new MapperConfig());
        });

        services.AddSingleton(config.CreateMapper());
        services.AddMediatR(typeof(CreateCustomerCommandHandler).Assembly);
        services.AddValidatorsFromAssemblyContaining<CustomerRequestValidator>();


        //services.AddTransient<CustomService1>();
        //services.AddScoped<CustomService2>();
        //services.AddSingleton<CustomService3>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Para.Api v1"));
        }


        app.UseMiddleware<LoggerMiddleware>();
        app.UseMiddleware<HeartbeatMiddleware>();

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseMiddleware<ErrorHandlerMiddleware>();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        //app.Use((context,next) =>
        //{
        //    if (!string.IsNullOrEmpty(context.Request.Path) && context.Request.Path.Value.Contains("favicon"))
        //    {
        //        return next();
        //    }

        //    var service1 = context.RequestServices.GetRequiredService<CustomService1>();
        //    var service2 = context.RequestServices.GetRequiredService<CustomService2>();
        //    var service3 = context.RequestServices.GetRequiredService<CustomService3>();

        //    service1.Counter++;
        //    service2.Counter++;
        //    service3.Counter++;

        //    return next();
        //});

        //app.Run(async context =>
        //{
        //    var service1 = context.RequestServices.GetRequiredService<CustomService1>();
        //    var service2 = context.RequestServices.GetRequiredService<CustomService2>();
        //    var service3 = context.RequestServices.GetRequiredService<CustomService3>();

        //    if (!string.IsNullOrEmpty(context.Request.Path) && !context.Request.Path.Value.Contains("favicon"))
        //    {
        //        service1.Counter++;
        //        service2.Counter++;
        //        service3.Counter++;
        //    }

        //    await context.Response.WriteAsync($"Service1 : {service1.Counter}\n");
        //    await context.Response.WriteAsync($"Service2 : {service2.Counter}\n");
        //    await context.Response.WriteAsync($"Service3 : {service3.Counter}\n");
        //});
    }
}