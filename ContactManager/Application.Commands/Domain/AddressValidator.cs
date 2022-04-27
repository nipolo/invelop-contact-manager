using FluentValidation;

namespace INV.ContactManager.Application.Commands.Domain
{
	public class AddressValidator : AbstractValidator<Address>
	{
		public AddressValidator()
		{
			RuleFor(address => address.Line1).NotNull().NotEmpty();
			RuleFor(address => address.Postcode).NotNull().NotEmpty();
			RuleFor(address => address.City).NotNull().NotEmpty();
			RuleFor(address => address.Country).NotNull().NotEmpty();
		}
	}
}
