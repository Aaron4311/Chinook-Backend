using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
	public class PlaylistTrackValidator : AbstractValidator<PlaylistTrack>
	{
        public PlaylistTrackValidator()
        {
            RuleFor(x => x.PlaylistId).NotNull();
			RuleFor(x => x.TrackId).NotNull();

		}
	}
}
