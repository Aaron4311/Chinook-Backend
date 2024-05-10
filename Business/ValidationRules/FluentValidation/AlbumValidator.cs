using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class AlbumValidator : AbstractValidator<Album>
    {
        public AlbumValidator()
        {
            RuleFor(x => x.AlbumId).NotNull();
            RuleFor(x => x.Title).NotNull();
        }
    }
}
