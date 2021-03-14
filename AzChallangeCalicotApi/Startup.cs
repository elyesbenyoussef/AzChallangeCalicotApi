using AutoMapper;
using AzChallangeCalicotApi.Data;
using AzChallangeCalicotApi.Service;
using AzChallangeCalicotApi.services;
using AzChallangeCalicotApi.Type;
using AzChallangeCalicotApi.Type.Helpers;
using AzChallangeCalicotApi.Type.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AzChallangeCalicotApi
{
    public class Startup
    {
        private AppSettings _config;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _config = new AppSettings();
            Configuration.Bind("AppSettings", _config);

            services.AddDbContext<CalicotContextExtension>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers();
            services.AddSingleton(_config);

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfile());
            });
            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddSingleton(new MapHelper(mapper));

            services.AddCors();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IDataService, DataService>();
            services.AddScoped<IBlobStorageService, BlobStorageService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors(option =>
            option.WithOrigins(_config.AngularUrl)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowAnyOrigin());
                

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
