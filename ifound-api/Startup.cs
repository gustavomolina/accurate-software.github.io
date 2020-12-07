using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.Json;
using Newtonsoft.Json.Serialization;
using System.Security.Principal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNet.OData.Extensions;

namespace ifound_api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(mvcOptions =>
                mvcOptions.EnableEndpointRouting = false);
            services.AddControllersServices();
            services.AddMvcServices();
            services.AddCors();
            services.AddHttpContextAccessor();
            services.ConfigureCompression();
            services.AddJWTAuthentication(Configuration);
            services.AddOData();
            ContainerIoc.InitializeIoC(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHttpsRedirection();

            app.UseRouting();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseResponseCompression();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseMvc(routeBuilder =>
            {
                routeBuilder.EnableDependencyInjection();
                routeBuilder.Expand().Select().Count().OrderBy().Filter();
            });
        }
    }
}
