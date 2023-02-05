using Microsoft.EntityFrameworkCore;
using CosmeticApp5.Data;
using CosmeticApp5.Models;
using CosmeticApp5.Services;

namespace CosmeticApp5
{
    public class Startup
    {
            public string ConnectionString { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
            public Startup(IConfiguration configuration)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
            {
                Configuration = configuration;
#pragma warning disable CS8601 // Possible null reference assignment.
                ConnectionString = Configuration.GetConnectionString("DefaultConnectionString");
#pragma warning restore CS8601 // Possible null reference assignment.
            }
            public IConfiguration Configuration { get; }
            //public object ConnectionStringIntializer { get; private set; }

            public void ConfigureServices(IServiceCollection services)
            {
                // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
                services.AddSwaggerGen();

              
                services.AddDbContext<AppDbContext>(options => options.UseSqlServer(ConnectionString));
                
               services.AddScoped<ProductService>();
            }
            public void Configure(IApplicationBuilder app)
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Employee API V1");
                });
                // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
                //AppDbInitializer.Seed(app);

            }
        }
    }

