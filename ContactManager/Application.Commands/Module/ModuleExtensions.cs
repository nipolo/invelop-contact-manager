using FluentValidation;

using INV.ContactManager.Application.Commands.Abstractions;
using INV.ContactManager.Application.Commands.Domain;
using INV.ContactManager.Application.Commands.Services;
using INV.ContactManager.Data.Module;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace INV.ContactManager.Application.Commands.Module
{
    public static class ModuleExtensions
    {
        public static IServiceCollection AddApplicationCommandsModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataModule(configuration);

            services.AddValidatorsFromAssemblyContaining<ContactValidator>();

            services.AddScoped<IContactService, ContactService>();

            return services;
        }
    }
}
