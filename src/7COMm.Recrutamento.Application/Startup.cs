using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using _7COMm.Recrutamento.Business.Services;
using _7COMm.Recrutamento.Business.Services.Interfaces;
using System.ComponentModel;
using Microsoft.AspNetCore.Http;
using _7COMm.Recrutamento.Application.WebUI.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using _7COMm.Recrutamento.Domain.Interfaces;
using _7COMm.Recrutamento.Domain.Services;
using _7COMm.Recrutamento.Data.EntityObjectsRepositorys;

namespace _7COMm.Recrutamento.Application
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DataBase7Com"));
            });
            ConfigureBussinessApplication(services);
            ConfigureData(services);
            ConfigureDomain(services);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            LoadConfigSwagger(services);


            var provider = services.BuildServiceProvider();
        }

        private static void ConfigureBussinessApplication(IServiceCollection services)
        {
            //services.AddTransient<IContato, ContatoApplication>();
            //services.AddSingleton<IContato, ContatoApplication>();
            services.AddScoped<IContato, ContatoApplication>();
            services.AddScoped<IOcorrencia, OcorrenciaApplication>();
            services.AddScoped<IJogoDaVelha, JogoDaVelhaApplication>();
        }
        private static void ConfigureData(IServiceCollection services)
        {
            services.AddScoped<IContatoRepository, ContatoRepository>();
        }

        private static void ConfigureDomain(IServiceCollection services)
        {
            services.AddScoped<IContatoService, ContatoService>();
            services.AddScoped<IOcorrenciaService, OcorrenciaService>();
            services.AddScoped<IJogoDaVelhaService, JogoDaVelhaService>();
        }






        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "7COMm Recrutamento");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private void LoadConfigSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "7COMm Recrutamento",
                        Version = "v1",
                        Description = "Projeto para avaliação de candidato",
                        Contact = new Contact
                        {
                            Name = "7COMm Serviços e Soluções em TI",
                            Url = "https://www.7comm.com.br/"
                        }
                    });

                string caminhoAplicacao = AppDomain.CurrentDomain.BaseDirectory;
                string nomeAplicacao = AppDomain.CurrentDomain.FriendlyName;
                string caminhoXmlDoc = Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");

                c.IncludeXmlComments(caminhoXmlDoc);
            });
        }


    }
}
