using INV.ContactManager.Data.Adapter;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace INV.ContactManager.Data.Module
{
	public static class ModuleExtensions
	{
		private static bool IsAdded { get; set; } = false;

		public static IServiceCollection AddDataModule(this IServiceCollection services, IConfiguration configuration)
		{
			if (!IsAdded)
			{
				var contactManagerConnectionString = configuration.GetConnectionString(DBConsts.CONTACT_MANAGER_DB_NAME);

				services.AddDbContextFactory<ContactManagerDBContext>(
					options => options.UseNpgsql(contactManagerConnectionString));

				IsAdded = true;
			}

			return services;
		}
	}
}
