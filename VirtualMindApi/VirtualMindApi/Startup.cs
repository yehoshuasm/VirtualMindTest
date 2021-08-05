using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VirtualMindApi.Database;
using VirtualMindApi.Providers;
using VirtualMindApi.Providers.BancoProvincia;
using VirtualMindApi.Services;
using Microsoft.EntityFrameworkCore;

namespace VirtualMindApi
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
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    b => b.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                );
            });

            services.AddControllers();

            services.AddDbContext<VirtualMindDbContext>(opt => opt.UseInMemoryDatabase("VirtualMindDb"));

            services.AddScoped<ICurrencyExchangeServiceFactory, CurrencyExchangeRateServiceFactory>();
            services.AddScoped<IDollarExchangeRateProvider, BancoProvinciaDollarExchangeRateProvider>();
            services.AddScoped<ICurrenciesService, CurrenciesService>();
            services.AddScoped<ICurrencyPurchasingService, CurrencyPurrchasingService>();

            services.AddScoped<DollarExchangeRateService>();
            services.AddScoped<RealExchangeRateService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors("CorsPolicy");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
