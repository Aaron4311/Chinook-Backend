using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
	public class TrackValidator : AbstractValidator<Track>
	{
        public TrackValidator()
        {
            RuleFor(x => x.TrackId).NotNull();
			RuleFor(x => x.Composer).NotNull();
			RuleFor(x => x.Milliseconds).NotNull();
			RuleFor(x => x.Name).NotNull().MaximumLength(25);
			RuleFor(x => x.UnitPrice).NotNull().GreaterThan(0);
			

		}
	}
}
