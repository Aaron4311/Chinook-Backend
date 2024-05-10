using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
	public class GenreValidator : AbstractValidator<Genre>
	{
        public GenreValidator()
        {
            RuleFor(x => x.GenreId).NotNull();
			RuleFor(x => x.Name).NotNull().MaximumLength(25);

		}
	}
}
