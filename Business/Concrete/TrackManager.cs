using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Chinook_Backend.Aspects.Validation;
using Chinook_Backend.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class TrackManager : ITrackService
	{
		private ITrackDal _trackDal;

		public TrackManager(ITrackDal trackDal)
		{
			_trackDal = trackDal;
		}

		[ValidationAspect(typeof(TrackValidator))]
		[SecuredOperation("admin,editor")]
		public IResult Add(Track track)
		{
			_trackDal.Add(track);
			return new SuccessResult();
		}

		[SecuredOperation("admin")]
		public IResult Delete(int id)
		{
			var deletedTrack = _trackDal.Get(x => x.TrackId == id);
			_trackDal.Delete(deletedTrack);
			return new SuccessResult();
		}

		[SecuredOperation("admin,editor,user")]
		public IDataResult<Track> Get(int id)
		{
			return new SuccessDataResult<Track>(_trackDal.Get(x => x.TrackId == id));
		}

		[SecuredOperation("admin,editor")]
		public IDataResult<List<Track>> GetAll()
		{
			return new SuccessDataResult<List<Track>>(_trackDal.GetAll());

		}

		[ValidationAspect(typeof(TrackValidator))]
		[SecuredOperation("admin")]
		public IResult Update(Track track)
		{
			_trackDal.Update(track);
			return new SuccessResult();
		}
	}
}
