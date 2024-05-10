using Entity.Concrete;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
	public class InvoiceValidator : AbstractValidator<Invoice>
	{
        public InvoiceValidator()
        {
            RuleFor(x => x.InvoiceId).NotNull();
			RuleFor(x => x.BillingAddress).NotNull();
			RuleFor(x => x.BillingCity).NotNull();
			RuleFor(x => x.BillingCountry).NotNull();
			RuleFor(x => x.BillingPostalCode).NotNull();
			RuleFor(x => x.BillingState).NotNull();
			RuleFor(x => x.InvoiceDate).NotNull();
			RuleFor(x => x.Total).NotNull();



		}
	}
}
