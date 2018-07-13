using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RepublicManager.Api.Core;
using RepublicManager.Api.Core.Repositories;
using RepublicManager.Api.Persistance;
using RepublicManager.Api.Persistance.Repositories;

namespace RepublicManager.Api
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

            var hostName = System.Net.Dns.GetHostName();
            if (hostName == "Annon")
            {
                var connection = @"Server=ANNON\SQLEXPRESS;Database=RepublicManager;Trusted_Connection=True;ConnectRetryCount=0";
                services.AddDbContext<RepublicManagerContext>(options => options.UseSqlServer(connection));
            }
            else
            {
                var connection = @"Server=DESKTOP-OCC8KVA\SQLEXPRESS;Database=RepublicManager;Trusted_Connection=True;ConnectRetryCount=0";
                services.AddDbContext<RepublicManagerContext>(options => options.UseSqlServer(connection));
            }

            //var connection = @"Server='amazonaws.cf79yuvlvuez.us-east-2.rds.amazonaws.com';Database=RepublicManager;User Id=fuktik;Password:dsjhonatan1337;";
         

            //injeção de dependencia
            //services.AddScoped<>()
            services.AddScoped<IAvisoRepositorio, AvisoRepositorio>();

            services.AddScoped<IRepublicaRepositorio, RepublicaRepositorio>();

            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
            services.AddScoped<ICarrinhoDeCompraRepositorio, CarrinhoDeCompraRepositorio>();

            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddScoped<ITarefaRepositorio, TarefaRepositorio>();
            services.AddScoped<ITarefaUsuarioRepositorio, TarefaUsuarioRepositorio>();

            services.AddScoped<IContaRepositorio, ContaRepositorio>();
            services.AddScoped<IContaAPagarRepositorio, ContaAPagarRepositorio>();
            services.AddScoped<IContaAReceberRepositorio, ContaAReceberRepositorio>();
            services.AddScoped<ITipoContaRepositorio, TipoContaRepositorio>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddMvc();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
