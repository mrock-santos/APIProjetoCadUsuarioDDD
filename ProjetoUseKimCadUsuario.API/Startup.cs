using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ProjetoUseKimCadUsuario.Application.Interfaces;
using ProjetoUseKimCadUsuario.Application.Services;
using ProjetoUseKimCadUsuario.Domain.Interfaces;
using ProjetoUseKimCadUsuario.Infrastructure.Data;
using ProjetoUseKimCadUsuario.Infrastructure.Interfaces;
using ProjetoUseKimCadUsuario.Infrastructure.Repositories;
using ProjetoUseKimCadUsuario.Infrastructure.Services;


namespace ProjetoUseKimCadUsuario.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();
            services.AddScoped<IExternalService, ExternalService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProjetoUseKimCadUsuario", Version = "v1" });
            });
        }
        /// <summary>
        /// Chamada do Swagger https://localhost:44363/swagger/index.html
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error"); // Define uma rota para tratamento de erro
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjetoUseKimCadUsuario v1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}
