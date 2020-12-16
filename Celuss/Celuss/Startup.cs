using AutoMapper;
using Celuss.Domain.DTOs;
using Celuss.Infrastructure.Contexts;
using Celuss.Infrastructure.Entities;
using Celuss.Infrastructure.Ioc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Celuss
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
            RegisterServices(services);
            services.AddDbContext<DataContext>(options => options
            .UseSqlServer(Configuration.GetConnectionString("CelussConnection")));

            services.AddControllers()
                    .AddNewtonsoftJson(options =>
                     options.SerializerSettings.ReferenceLoopHandling =
                     Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddAutoMapper(configuration =>
             {
                 configuration.CreateMap<Appointment, AppointmentRequest>()
                 .ReverseMap();
                 configuration.CreateMap<Customer, CustomerRequest>()
                 .ReverseMap();
                 configuration.CreateMap<Doctor, DoctorRequest>()
                 .ReverseMap();
                 configuration.CreateMap<IPS, IPSRequest>()
                 .ReverseMap();
             }, typeof(Startup));


            services.AddCors(options =>
            {
                options.AddPolicy("FullPages", builder =>
                builder
                //.WithOrigins("http://localhost:4200/")
                .WithOrigins("*")
                .WithMethods("*")
                .WithHeaders("*"));
            });
        }
        private static void RegisterServices(IServiceCollection services)
        {
            DependenciesContainer.RegisterServices(services);
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
            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
