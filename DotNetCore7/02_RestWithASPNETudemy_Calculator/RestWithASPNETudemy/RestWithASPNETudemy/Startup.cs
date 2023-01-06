using Microsoft.EntityFrameworkCore;
using RestWithASPNETudemy.Model.Context;
using RestWithASPNETudemy.Business;
using RestWithASPNETudemy.Business.Implementations;
using RestWithASPNETudemy.Repository;
using RestWithASPNETudemy.Repository.Implementations;
using Serilog;
using EvolveDb;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Rewrite;

namespace DotNetCore5
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration   = configuration;
            Environment     = environment;

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            }));
            services.AddControllers();

            var connection  = Configuration["MySQLConnection:MySQLConnectionString"];

            services.AddDbContext<MySQLContext>(options =>  options.UseMySql(connection, ServerVersion.AutoDetect(connection)));

            if (Environment.IsDevelopment())
            {
                MigrateDataBase(connection);
            }

            /// Version API
            services.AddApiVersioning();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "RestGuidoUdemy",
                        Version = "v1",
                        Description = "Teste",
                        Contact = new OpenApiContact
                        {
                            Name = "Eduardo",
                            Url = new Uri("https://www.lojasguido.com.br")
                        }
                    });
            });

            /// Dependency Injection
            services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
            services.AddScoped<IPersonRepository, PersonRepositoryImplementation>();
            services.AddScoped<IBooksBusiness, BooksBusinessImplementation>();
            services.AddScoped<IBooksRepository, BooksRepositoryImplemantation>();
            services.AddScoped<IAppAgendaCDBusiness, AppAgendaCDBusinessImplementation>();
            services.AddScoped<IAppAgendaCDRepository, AppAgendaCDRepositoryImplementation>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RestGuidoUdemy v1"));

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private void MigrateDataBase(string? connection)
        {
            try
            {
                var envolveConnection = new MySql.Data.MySqlClient.MySqlConnection(connection);
                var evolve = new EvolveDb.Evolve(envolveConnection, msg => Log.Information(msg))
                {
                    Locations = new List<string> { "db/migrations", "db/dataset" },
                    IsEraseDisabled = true,
                };
                evolve.Migrate();
            }
            catch (Exception ex)
            {
                Log.Error("Datebase migration failed", ex);
                throw;
            }
        }
    }
}
