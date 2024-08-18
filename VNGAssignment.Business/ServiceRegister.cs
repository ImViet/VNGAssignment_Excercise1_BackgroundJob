using Microsoft.Extensions.DependencyInjection;
using VNGAssignment.Business.Interfaces;
using VNGAssignment.Business.Services;
using MailKit;

namespace VNGAssignment.Business
{
    public static class ServiceRegister
    {
        public static void AddBusinessLayer( this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IEmailService, EmailService>();
        }
    }
}
