using INV.ContactManager.Data.States;

using Microsoft.EntityFrameworkCore;

namespace INV.ContactManager.Data.Adapter
{
	public class ContactManagerDBContext : DbContext
	{
		public ContactManagerDBContext(DbContextOptions<ContactManagerDBContext> options)
	: base(options)
		{
		}

		public DbSet<ContactState> Contacts { get; set; }

		public void EnsureDBMigrated()
		{
			Database.Migrate();
			Database.EnsureCreated();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.EnableSensitiveDataLogging();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ContactState>()
				.HasKey(a => a.Id);

			modelBuilder.Entity<ContactState>()
				.Property(a => a.Id)
				.ValueGeneratedOnAdd();

			modelBuilder.Entity<ContactState>()
				.Property(a => a.FirstName)
				.IsRequired(true);

			modelBuilder.Entity<ContactState>()
				.Property(a => a.Surname)
				.IsRequired(true);

			modelBuilder.Entity<ContactState>()
				.Property(a => a.BirthDate)
				.IsRequired(true);

			modelBuilder.Entity<ContactState>()
				.Property(a => a.PhoneNumber)
				.IsRequired(true);

			modelBuilder.Entity<ContactState>()
				.Property(a => a.IBAN)
				.IsRequired(true);

			modelBuilder.Entity<ContactState>()
				.Property(b => b.Address)
				.IsRequired(true)
				.HasColumnType("jsonb");
		}
	}
}
