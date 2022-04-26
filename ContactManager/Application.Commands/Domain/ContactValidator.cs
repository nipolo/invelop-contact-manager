using System;

using FluentValidation;

using INV.Common.Libraries.Validations;

namespace INV.ContactManager.Application.Commands.Domain
{
	public class ContactValidator : AbstractValidator<Contact>
	{
		public ContactValidator()
		{
			RuleFor(x => x.FirstName).NotNull().NotEmpty();
			RuleFor(x => x.Surname).NotNull().NotEmpty();
			RuleFor(x => x.BirthDate).NotEqual(default(DateTime));
			RuleFor(x => x.Address).SetValidator(new AddressValidator());
			RuleFor(x => x.PhoneNumber).NotNull().NotEmpty()
				.Matches(ValidationRegexConsts.PhoneNumber);
			RuleFor(x => x.IBAN).NotNull().NotEmpty().Matches(ValidationRegexConsts.IBAN);
		}
	}
}
