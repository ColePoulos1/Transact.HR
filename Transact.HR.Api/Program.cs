
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Transact.HR.Api.Controllers;
using Transact.HR.DataAccess;

namespace Transact.HR.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            ConfigureApiSetup(builder.Services);
            ConfigureDbSetup(builder.Services);

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint($"/swagger/V1/swagger.json", "V1.0");
                });
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        public static void ConfigureApiSetup(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("V1", new OpenApiInfo() { Title = "API V1", Version = "V1.0" });
                options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                options.CustomSchemaIds(x => x.FullName);
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,$"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
            });
            services.AddApiVersioning(
                options =>
                {
                    options.DefaultApiVersion = new ApiVersion(1, 0);
                    options.AssumeDefaultVersionWhenUnspecified = true;
                    options.ReportApiVersions = true;
                    options.Conventions.Controller<EmployeeController>().HasApiVersion(new ApiVersion(1, 0));
                });
            services.AddVersionedApiExplorer();

        }

        public static void ConfigureDbSetup(IServiceCollection services)
        {
            services.AddDbContext<HrContext>(
                options =>
                {
                    options.UseSqlite($"Data Source={Path.Join(AppDomain.CurrentDomain.BaseDirectory, "hr.db")}");
                });
        }
    }
}