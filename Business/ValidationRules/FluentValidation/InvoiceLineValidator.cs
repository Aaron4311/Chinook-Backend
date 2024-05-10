using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
	public class InvoiceLineValidator : AbstractValidator<InvoiceLine>
	{
        public InvoiceLineValidator()
        {
            RuleFor(x => x.InvoiceLineId).NotNull();
			RuleFor(x => x.Quantity).NotNull();
			RuleFor(x => x.UnitPrice).NotNull().GreaterThan(0);

		}
	}
}
