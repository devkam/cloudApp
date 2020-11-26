using AutoMapper;
using System;
using cloudApp.Helpers;
using cloudApp.Models;
using cloudApp.Persistence;
using cloudApp.Persistence.Interfaces;
using cloudApp.Services.Api;
using cloudApp.Services.Api.Interfaces;
using cloudApp.Services.Azure;
using cloudApp.Services.Azure.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace cloudApp
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
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            var appSettings = appSettingsSection.Get<AppSettings>();

            services.AddDbContext<DataContext>();
            services.AddControllers();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // DI services
            // api
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IImageService, ImageService>();

            // azure
            services.AddSingleton<IAzKeyVaultService>(new AzKeyVaultService(appSettings.KeyVaultName));
            services.AddScoped<IAzBlobStorageService, AzBlobStorageService>(); // transient?
            services.AddScoped<IAzQueueStorageService, AzQueueStorageService>();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
