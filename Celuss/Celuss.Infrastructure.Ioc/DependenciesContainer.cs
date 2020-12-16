using Celuss.Infrastructure.Repositories;
using Celuss.Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Celuss.Infrastructure.Ioc
{
    public class DependenciesContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {

            services.AddTransient<IAppointmentRepository, AppointmentRepository>();
            services.AddTransient<ICustomerRespository, CustomerRespository>();
            services.AddTransient<IDoctorRepository, IDoctorRepository>();
            services.AddTransient<IIPSRepository, IPSRepository>();


           // services.AddScoped<INumberService, NumberService>();

        }
    }
}
