
using Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Linq;
using Repositorio;
using Repositorio.DataContext;
using Repositorio.Interfaces;
using Servico;
using Servico.Interfaces;

namespace GerenciadorTarefas_Api
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
            string stringConnection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<GerenciadorTarefasContext>(options =>
                options.UseMySql(stringConnection, ServerVersion.AutoDetect(stringConnection)));


            
            // Adicione as dependências
            // services.AddScoped(typeof(Servico<>), typeof(SuaImplementacaoServico<>));

            services.AddScoped<ITarefaRepositorio<Tarefa>, TarefaRepositorio<Tarefa>>();
            services.AddSingleton<ITarefaServico, TarefaServico>();


            services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            })
            .ConfigureApiBehaviorOptions(options =>
            {
                // Configurações adicionais do comportamento da API, se necessário.
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProjetoAPI", Version = "v1" });
            });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjetoAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseAuthentication(); // Isso que aplica autenticação na api.

            app.UseRouting();

            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}