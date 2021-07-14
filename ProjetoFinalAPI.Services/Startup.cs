using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ProjetoFinalAPI.Repository.Context;
using ProjetoFinalAPI.Repository.Interfaces;
using ProjetoFinalAPI.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinalAPI.Services
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
            services.AddControllers();

            #region EntityFramework

            //configurar a classe DbContext (SqlServerContext)
            services.AddDbContext<SqlServerContext>
            (options => options.UseSqlServer
            (Configuration.GetConnectionString("ProjetoFinalAPI")));
            //adicionar as interfaces / classes
            //de repositorio criadas no projeto..
            services.AddTransient<IProfissionalRepository,
            ProfissionalRepository>();
            services.AddTransient<IServicoRepository,
            ServicoRepository>();

            #endregion

            #region Swagger

            services.AddSwaggerGen(
                swagger =>
                {
                    swagger.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "APIPROJETOFINAL",
                        Description = "API REST desenvolvida em .NET CORE com EntityFramework",
                        Version = "v1",
                        Contact = new OpenApiContact
                        {
                            Name = "PROJETO FINAL",
                            //Url = new Uri(""),
                            //Email = ""
                        }
                    });
                }
                );

            #endregion

            #region AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            #region Swagger

            app.UseSwagger();
            app.UseSwaggerUI(swagger => { swagger.SwaggerEndpoint("/swagger/v1/swagger.json", "API PROJETO FINAL"); });

            #endregion

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
