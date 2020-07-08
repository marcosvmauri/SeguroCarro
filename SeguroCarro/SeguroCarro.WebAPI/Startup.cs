using SeguroCarro.Repository.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;

namespace SeguroCarro.WebAPI
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
            services.AddMvc();

            Ioc.AddRepositorysDependencies(services);
            Ioc.AddServicesDependencies(services);
            
            services.AddEntityFrameworkOracle().AddDbContext<SeguroCarroContext>(options =>
            {
                options.UseOracle(Configuration.GetConnectionString("DefaultConnection"));
            });

            var documentationPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SeguroCarro.Api.xml");

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "WebSaudeApi", Version = "v1" });
                if (File.Exists(documentationPath)) { c.IncludeXmlComments(documentationPath); }               
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseMvc();
        }
    }
}
