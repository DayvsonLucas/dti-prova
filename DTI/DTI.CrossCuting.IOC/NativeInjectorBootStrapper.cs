
using Microsoft.AspNetCore.Http;
using DTI.Domain.Core.Notifications;
using DTI.Domain.Entities;
using DTI.Domain.Validations;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using DTI.Infra.Data.Interface;
using DTI.Infra.Data.Repository;
using DTI.Application.Interface;
using DTI.Application.Services;

namespace DTI.CrossCuting.IOC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            InfraData(services);
            Services(services);
            Notification(services);
            Validators(services);
        }

        private static void InfraData(IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
        }
        private static void Services(IServiceCollection services)
        {
            services.AddScoped<IProductServices, ProductServices>();
        }
        private static void Notification(IServiceCollection services)
        {
            services.AddScoped<INotificationHandler, DomainNotificationHandler>();
        }
        private static void Validators(IServiceCollection services)
        {
            services.AddSingleton<IValidator<Product>, ProductValidator>();
        }
    }
}
