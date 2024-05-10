using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
	public class CustomerValidator : AbstractValidator<Customer>
	{
        public CustomerValidator()
        {
            RuleFor(x => x.CustomerId).NotNull();
            RuleFor(x => x.Phone).NotNull();
            RuleFor(x => x.Address).NotNull().MaximumLength(250);
            RuleFor(x => x.Email).NotNull().EmailAddress();
            RuleFor(x => x.City).NotNull().MaximumLength(25);
            RuleFor(x => x.Company).NotNull().MaximumLength(25);   
            RuleFor(x => x.Country).NotNull().MaximumLength(25);  
            RuleFor(x => x.FirstName).NotNull().MinimumLength(2).MaximumLength(25);
			RuleFor(x => x.LastName).NotNull().MinimumLength(2).MaximumLength(25);
			RuleFor(x => x.PostalCode).NotNull();
			RuleFor(x => x.State).NotNull().MaximumLength(25);




		}
	}
}
