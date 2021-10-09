
using API.Usuarios.Models;
using API.Usuarios.Repository;
using API.Usuarios.Repository.Implementation;
using API.Usuarios.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace API.Usuarios
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
            string mySqlConnectionStr = Configuration.GetConnectionString("MysqlConn");
            services.AddDbContextPool<MyDBContext>(options => options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));

            //services.AddSingleton<IConfiguracionService, ConfiguracionService>();
            services.AddScoped<IConfiguracionService, ConfiguracionService>();
            services.AddScoped<IUsuarioCursoOracleService, UsuarioCursoOracleService>();
            services.AddScoped<IMigracionService, MigracionService>();
            services.AddTransient<IConfigurationRepository, ConfiguracionRepository>();
            services.AddTransient<IUsuarioCursoOracleRepository, UsuarioCursoOracleRepository>();
            services.AddTransient<IMigracionRepository, MigracionRepository>();

            services.AddControllers();
            

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API.Usuarios", Version = "v1" });                
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API.Usuarios v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
