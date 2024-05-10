using Entity.Dtos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
	public class UserForLoginDtoValidator : AbstractValidator<UserForLoginDto>
	{
		public UserForLoginDtoValidator()
		{
			RuleFor(x => x.Email).NotNull().EmailAddress();
			RuleFor(x => x.Password).NotNull();

		}
	}
}
