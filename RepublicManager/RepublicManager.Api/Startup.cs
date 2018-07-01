using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
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
            services.AddMvc();
            //injeção de dependencia
            services.AddScoped<IRepublicaRepositorio, RepublicaRepositorio>();

            var connection = @"Server=DESKTOP-OCC8KVA\SQLEXPRESS;Database=RepublicManager;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<RepublicManagerContext>(options => options.UseSqlServer(connection));

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
