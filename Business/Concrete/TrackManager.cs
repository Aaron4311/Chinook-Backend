using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Chinook_Backend.Aspects.Caching;
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
		[CacheRemovingAspect("ITrackService.Get")]
		public IResult Add(Track track)
		{
			_trackDal.Add(track);
			return new SuccessResult(Messages.trackAdded);
		}

		[SecuredOperation("admin")]
		[CacheRemovingAspect("ITrackService.Get")]
		public IResult Delete(int id)
		{
			var deletedTrack = _trackDal.Get(x => x.TrackId == id);
			_trackDal.Delete(deletedTrack);
			return new SuccessResult(Messages.trackDeleted);
		}

		[SecuredOperation("admin,editor,user")]
		[CachingAspect]
		public IDataResult<Track> Get(int id)
		{
			return new SuccessDataResult<Track>(_trackDal.Get(x => x.TrackId == id),Messages.trackListed);
		}

		[SecuredOperation("admin,editor")]
		[CachingAspect]
		public IDataResult<List<Track>> GetAll()
		{
			return new SuccessDataResult<List<Track>>(_trackDal.GetAll(), Messages.trackListed);

		}

		[ValidationAspect(typeof(TrackValidator))]
		[SecuredOperation("admin")]
		public IResult Update(Track track)
		{
			_trackDal.Update(track);
			return new SuccessResult(Messages.trackUpdated);
		}
	}
}
