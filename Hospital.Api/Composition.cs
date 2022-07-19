using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Api
{
    public static class Composition
    {
        public static void RegisterDependency(this IServiceCollection services)
        {
            RegisterRepositories(services);
            RegisterServices(services);
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IGeneralRepository, GeneralRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<ISiteRepository, SiteRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IParlorRepository, ParlorRepository>();
            services.AddScoped<ISpecializationRepository, SpecializationRepository>();
        }
        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<DoctorService>();
        }
    }
}
