using System;

namespace INV.ContactManager.Application.Commands.Domain
{
	public class Contact
	{
		public int Id { get; set; }

		public string FirstName { get; set; }

		public string Surname { get; set; }

		public DateTime BirthDate { get; set; }

		public Address Address { get; set; }

		public string PhoneNumber { get; set; }

		public string IBAN { get; set; }

		public DateTime CreatedOn { get; set; }

		public DateTime UpdatedOn { get; set; }

		public static Contact Create(
			string firstName,
			string surname,
			DateTime birthDate,
			string phoneNumber,
			string iban,
			string line1,
			string line2,
			string postcode,
			string city,
			string country)
		{
			var now = DateTime.UtcNow;

			return new Contact()
			{
				Address = new Address(line1, line2, postcode, city, country),
				BirthDate = birthDate,
				FirstName = firstName,
				IBAN = iban,
				PhoneNumber = phoneNumber,
				Surname = surname,
				CreatedOn = now,
				UpdatedOn = now
			};
		}

		public static Contact Load(
			int id,
			string firstName,
			string surname,
			DateTime birthDate,
			string phoneNumber,
			string iban,
			string line1,
			string line2,
			string postcode,
			string city,
			string country,
			DateTime createdOn,
			DateTime updatedOn)
		{
			return new Contact()
			{
				Id = id,
				Address = new Address(line1, line2, postcode, city, country),
				BirthDate = birthDate,
				FirstName = firstName,
				IBAN = iban,
				PhoneNumber = phoneNumber,
				Surname = surname,
				CreatedOn = createdOn,
				UpdatedOn = updatedOn
			};
		}

		public void Update(
			string firstName,
			string surname,
			DateTime birthDate,
			string phoneNumber,
			string iban,
			string line1,
			string line2,
			string postcode,
			string city,
			string country)
		{
			var now = DateTime.UtcNow;

			BirthDate = birthDate;
			FirstName = firstName;
			IBAN = iban;
			PhoneNumber = phoneNumber;
			Surname = surname;
			UpdatedOn = now;

			Address.Update(line1, line2, postcode, city, country);
		}
	}
}
