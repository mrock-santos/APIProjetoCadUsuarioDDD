using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ProjetoCadUsuario.Application.Interfaces;
using ProjetoCadUsuario.Application.Services;
using ProjetoCadUsuario.Domain.Interfaces;
using ProjetoCadUsuario.Infrastructure.Data;
using ProjetoCadUsuario.Infrastructure.Interfaces;
using ProjetoCadUsuario.Infrastructure.Repositories;
using ProjetoCadUsuario.Infrastructure.Services;


namespace ProjetoCadUsuario.API
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

            //services.AddDbContext<ApplicationDbContext>(options =>
            //  options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));


            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();
            services.AddScoped<IExternalService, ExternalService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProjetoCadUsuario", Version = "v1" });
            });
        }
        /// <summary>
        /// Chamada do Swagger https://localhost:44363/swagger/index.html
        /*    "nome": "Marcio Rocha dos Santos",
              "email": "mrock.santos@gmail.com",
              "documento": "27564849-7"
               
              "id": "f86ec0fb-0056-419e-b1f4-6991c22ef715",
              "nome": "Daniel Batista Rocha dos Santos",
              "email": "dbrock.santos@gmail.com",
              "documento": "27564849-7"

              "nome": "Ana Clara Rocha dos Santos",
              "email": "mrock.santos@gmail.com",
              "documento": "27564849-7"
            
              "nome": "Adriana da Gloria Santos",
              "email": "mrock.santos@gmail.com",
              "documento": "27564849-7"
        */
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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjetoCadUsuario v1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}
