using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RepublicManager.Api.Core;
using RepublicManager.Api.Core.Domain;
using RepublicManager.Api.Core.Repositories;
using RepublicManager.Api.Persistance;
using RepublicManager.Api.Persistance.Repositories;
using System;

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
            var corsBuilder = new CorsPolicyBuilder();
            corsBuilder.AllowAnyHeader().AllowAnyMethod().AllowCredentials()
                .WithOrigins("http://localhost:4200");
            //corsBuilder.AllowAnyOrigin(); // For anyone access.
            //corsBuilder.WithOrigins("http://localhost:4200"); // for a specific url. Don't add a forward slash on the end!

            services.AddCors(options =>
            {
                options.AddPolicy("SiteCorsPolicy", corsBuilder.Build());
            });

            //JWT authentication bellow

            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);

            var tokenConfigurations = new TokenConfigurations();
            new ConfigureFromConfigurationOptions<TokenConfigurations>(Configuration.GetSection("TokenConfigurations")).Configure(tokenConfigurations);
            services.AddSingleton(tokenConfigurations);

            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signingConfigurations.Key;
                paramsValidation.ValidAudience = tokenConfigurations.Audience;
                paramsValidation.ValidIssuer = tokenConfigurations.Issuer;

                paramsValidation.ValidateIssuerSigningKey = true;
                paramsValidation.ValidateLifetime = true;
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });

            services.AddAuthorization(auth =>
            {
                auth.DefaultPolicy = new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build();
                auth.AddPolicy("Administrators",
                    policy => policy.RequireClaim("Manager"));
                
                //auth.AddPolicy("SuperUsers",
                //    policy => policy.RequireClaim("SuperUser"));
            });

            //In case of multiple development environments
            var hostName = System.Net.Dns.GetHostName();
            if (hostName == "Annon")
            {
                var connection = @"Server=ANNON\SQLEXPRESS;Database=RepublicManager;Trusted_Connection=True;ConnectRetryCount=0";
                services.AddDbContext<RepublicManagerContext>(options => options.UseSqlServer(connection));
            }

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

            app.UseAuthentication();
            app.UseMvc();
            app.UseCors("SiteCorsPolicy");
        }
    }
}
