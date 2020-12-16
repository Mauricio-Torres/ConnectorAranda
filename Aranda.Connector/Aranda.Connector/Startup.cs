// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.Connector.Api.Helpers;
using Aranda.Connector.Api.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Linq;

namespace Aranda.Connector
{
    public class Startup
    {
        public readonly string AllowAllOriginsPolicy = "localhost";
        private const string _appConfiguration = "http://localhost:4200";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(AllowAllOriginsPolicy);

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Aranda Connector V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            DependencyInjection.Dependency(services);

            services.AddDistributedMemoryCache();

            services.AddCors(
              options => options.AddPolicy(
                  AllowAllOriginsPolicy,
                  builder => builder
                      .WithOrigins(
                          _appConfiguration
                              .Split(",", StringSplitOptions.RemoveEmptyEntries)
                              .ToArray()
                      )
                      .AllowAnyHeader()
                      .AllowAnyMethod()
                      .AllowCredentials()
              )
          );
            services.AddAuthentication("BasicAuthentication").
            AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>
            ("BasicAuthentication", null);

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Aranda Connector", Version = "v1" });
            });
        }
    }
}