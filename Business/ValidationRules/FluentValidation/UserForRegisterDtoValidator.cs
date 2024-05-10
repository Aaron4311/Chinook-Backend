using Entity.Dtos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
	public class UserForRegisterDtoValidator : AbstractValidator<UserForRegisterDto>
	{
		public UserForRegisterDtoValidator()
		{
			RuleFor(x => x.Email).EmailAddress().NotNull();
			RuleFor(x => x.FirstName).NotNull().MinimumLength(2);
			RuleFor(x => x.LastName).NotNull().MinimumLength(2);
		}
	}
}
