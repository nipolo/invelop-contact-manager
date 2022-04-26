namespace INV.Common.Libraries.Validations
{
	public static class ValidationRegexConsts
	{
		public const string PhoneNumber = "^\\+?[0-9]+(-[0-9]+)*$";

		public const string IBAN = "^[A-Z]{2}[0-9]{2}(-[0-9A-Z]{1,4})+$";
	}
}
