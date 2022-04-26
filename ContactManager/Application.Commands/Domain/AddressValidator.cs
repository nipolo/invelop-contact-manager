using FluentValidation;

namespace INV.ContactManager.Application.Commands.Domain
{
	public class AddressValidator : AbstractValidator<Address>
	{
		public AddressValidator()
		{
			RuleFor(address => address.Line1).NotNull();
			RuleFor(address => address.Postcode).NotNull();
			RuleFor(address => address.City).NotNull();
			RuleFor(address => address.Country).NotNull();
		}
	}
}
