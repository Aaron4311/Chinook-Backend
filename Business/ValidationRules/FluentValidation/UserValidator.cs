using Chinook_Backend.Entities.Concrete;
using DevFramework.Core.Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Business.ValidationRules.FluentValidation
{
	public class UserValidator : AbstractValidator<User>
	{
        public UserValidator()
        {
			RuleFor(x => x.Email).NotNull().EmailAddress();
			RuleFor(x => x.FirstName).NotEmpty();
			RuleFor(x => x.LastName).NotEmpty();
		
		}
    }
}
