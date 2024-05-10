using DevFramework.Northwind.Entities.Dtos;
using Entity.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Business.ValidationRules.FluentValidation
{
	public class UserForLoginDtoValidator : AbstractValidator<UserForLoginDto>
	{
        public UserForLoginDtoValidator()
        {
			RuleFor(x => x.Email).NotNull().EmailAddress();
			RuleFor(x => x.Password).NotNull()

		}
	}
}
