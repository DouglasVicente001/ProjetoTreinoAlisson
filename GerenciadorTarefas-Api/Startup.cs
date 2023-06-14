using GerenciadorTarefas_Api.Data;
using Microsoft.EntityFrameworkCore;

using Repositorio.ConfigureServices;

namespace GerenciadorTarefas_Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string stringConnection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<GerenciadorTarefasContext>(options =>
            options.UseMySql(stringConnection, ServerVersion.AutoDetect(stringConnection)));

            ConfigureServicesExtensao.ConfigureServices(services);
        }

        public void Configure(IServiceCollection services,IApplicationBuilder app, IWebHostEnvironment env)
        {
           ConfiguracaoStartup.Configure(services, app, env);
        }
    }
}