using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Persistence;
using Service;
using Swashbuckle.AspNetCore.Swagger;

namespace ProyectoAPI
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
            var connection = Configuration.GetConnectionString("Dev");
            services.AddDbContext<BreadDbContext>(options => options.UseSqlServer(connection));

            services.AddTransient<IClienteService, ClienteService>();

            services.AddTransient<ICompraService, CompraService>();

            services.AddTransient<IEmpleadoService, EmpleadoService>();

            services.AddTransient<IProductoService, ProductoService>();

            services.AddTransient<IProveedorService, ProveedorService>();

            services.AddCors(options =>
           {
               options.AddPolicy("AllowSpecificOrigin", builder =>
                   builder.AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowAnyOrigin()
                );
           });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v2", new Info { Title = "My Own API", Version = "v2" });
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
           {
               c.SwaggerEndpoint("/swagger/v2/swagger.json", "My Own API V1");
           });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
