namespace INV.ContactManager.Data.States
{
	public class AddressState
	{
		public AddressState(
			string line1,
			string line2,
			string postcode,
			string city,
			string country)
		{
			Line1 = line1;
			Line2 = line2;
			Postcode = postcode;
			City = city;
			Country = country;
		}

		public string Line1 { get; set; }

		public string Line2 { get; set; }

		public string Postcode { get; set; }

		public string City { get; set; }

		public string Country { get; set; }
	}
}
