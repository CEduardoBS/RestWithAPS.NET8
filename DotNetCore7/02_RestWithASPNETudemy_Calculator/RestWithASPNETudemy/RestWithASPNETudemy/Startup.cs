using Microsoft.EntityFrameworkCore;
using RestWithASPNETudemy.Model.Context;
using RestWithASPNETudemy.Service.Implementations;

namespace DotNetCore5
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            var connection  = Configuration["MySQLConnection:MySQLConnectionString"];
            var serverVersion = new MySqlServerVersion(new Version (8,0,25));

            services.AddDbContext<MySQLContext>(options =>  options.UseMySql(connection, ServerVersion.AutoDetect(connection)));

            /// Dependency Injection
            services.AddScoped<IPersonService, PersonServiceImplementation>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
