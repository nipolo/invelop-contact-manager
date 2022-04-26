using INV.ContactManager.Application.Queries.Abstractions;
using INV.ContactManager.Application.Commands.Services;
using INV.ContactManager.Data.Module;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace INV.ContactManager.Application.Queries.Module
{
    public static class ModuleExtensions
    {
        public static IServiceCollection AddApplicationQueriesModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataModule(configuration);

            services.AddSingleton<IContactQueryService, ContactQueryService>();

            return services;
        }
    }
}
