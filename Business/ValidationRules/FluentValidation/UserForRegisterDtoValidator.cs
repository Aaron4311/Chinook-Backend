﻿using DevFramework.Northwind.Entities.Dtos;
using Entity.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Business.ValidationRules.FluentValidation
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
