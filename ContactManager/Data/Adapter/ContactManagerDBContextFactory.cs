using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace INV.ContactManager.Data.Adapter
{
    public class ContactManagerDBContextFactory : IDesignTimeDbContextFactory<ContactManagerDBContext>
    {
        public ContactManagerDBContext CreateDbContext(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.Development.json", optional: false)
                .Build();

            var contactManagerConnectionString = config.GetConnectionString(DBConsts.CONTACT_MANAGER_DB_NAME);

            var optionsBuilder = new DbContextOptionsBuilder<ContactManagerDBContext>();

            optionsBuilder.UseNpgsql(contactManagerConnectionString);

            return new ContactManagerDBContext(optionsBuilder.Options);
        }
    }
}
