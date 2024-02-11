using Microsoft.EntityFrameworkCore;
using robot_application_v1.ApplicationLayer.Services;
using robot_application_v1.DomainModelLayer.Contracts;
using robot_application_v1.DomainModelLayer.Entities;
using robot_application_v1.InfrastructureLayer.BusinessLogic.Repository;

namespace robot_application_v1;

public class Startup
{
    private const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
    private IConfiguration Configuration { get; }

    public Startup(IHostEnvironment env)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables();
        Configuration = builder.Build();
    }

    /// This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("*").AllowAnyHeader();
                });
        });
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        var connection = Configuration["ConnectionStrings:SqliteConnectionString"];
        services.AddDbContext<RobotExecutionContext>(
            options => options.UseSqlite(connection));
      
        services.AddTransient<IExecutionRepository, ExecutionRepository>();
        services.AddScoped<RobotService>(); // handle robot service
        services.AddScoped<StoreService>(); // handle store service

        // add controller of this project
        services.AddControllers();
        
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddMvc();
    }
    
    /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, RobotExecutionContext context)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Robot.App v1"));
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
        
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseCors(MyAllowSpecificOrigins);
        //  app.UseAuthorization();

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}