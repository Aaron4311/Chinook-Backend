using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Chinook_Backend.Aspects.Caching;
using Chinook_Backend.Aspects.Validation;
using Chinook_Backend.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class PlaylistTrackManager : IPlaylistTrackService
	{
		private IPlaylistTrackDal _playlistTrackDal;

		public PlaylistTrackManager(IPlaylistTrackDal playlistTrackDal)
		{
			_playlistTrackDal = playlistTrackDal;
		}
		[ValidationAspect(typeof(PlaylistTrackManager))]
		[SecuredOperation("admin,editor")]
		[CacheRemovingAspect("IPlaylistTrackService.Get")]
		public IResult Add(PlaylistTrack playlistTrack)
		{
			_playlistTrackDal.Add(playlistTrack );
			return new SuccessResult(Messages.playlistTrackAdded);
		}

		[SecuredOperation("admin")]
		[CacheRemovingAspect("IPlaylistTrackService.Get")]
		public IResult Delete(int id)
		{
			var deletedTrack = _playlistTrackDal.Get(x => x.TrackId == id);
			_playlistTrackDal.Delete(deletedTrack);
			return new SuccessResult(Messages.playlistTrackDeleted);
		}

		[SecuredOperation("admin,editor,user")]
		[CachingAspect]
		public IDataResult<PlaylistTrack > Get(int id)
		{
			return new SuccessDataResult<PlaylistTrack >(_playlistTrackDal.Get(x => x.TrackId == id), Messages.playlistTrackListed);
		}

		[SecuredOperation("admin,editor")]
		[CachingAspect]
		public IDataResult<List<PlaylistTrack >> GetAll()
		{
			return new SuccessDataResult<List<PlaylistTrack >>(_playlistTrackDal.GetAll(),Messages.playlistTrackListed);

		}

		[ValidationAspect(typeof(PlaylistTrackManager))]
		[SecuredOperation("admin")]
		public IResult Update(PlaylistTrack playlistTrack)
		{
			_playlistTrackDal.Update(playlistTrack);
			return new SuccessResult(Messages.playlistTrackUpdated);
		}
	}
}
