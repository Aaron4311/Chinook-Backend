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
	public class PlaylistManager : IPlaylistService
	{
		private IPlaylistDal _playlistDal;

		public PlaylistManager(IPlaylistDal playlistDal)
		{
			_playlistDal = playlistDal;
		}

		[ValidationAspect(typeof(PlaylistValidator))]
		[SecuredOperation("admin,editor")]
		[CacheRemovingAspect("IPlaylistService.Get")]
		public IResult Add(Playlist playlist)
		{
			_playlistDal.Add(playlist);
			return new SuccessResult(Messages.playlistAdded);
		}

		[SecuredOperation("admin")]
		[CacheRemovingAspect("IPlaylistService.Get")]
		public IResult Delete(int id)
		{
			var deletedPlaylist = _playlistDal.Get(x => x.PlaylistId == id);
			_playlistDal.Delete(deletedPlaylist);
			return new SuccessResult(Messages.playlistDeleted);
		}

		[SecuredOperation("admin,editor,user")]
		[CachingAspect]
		public IDataResult<Playlist > Get(int id)
		{
			return new SuccessDataResult<Playlist >(_playlistDal.Get(x => x.PlaylistId == id), Messages.playlistListed);
		}

		[SecuredOperation("admin,editor")]
		[CachingAspect]
		public IDataResult<List<Playlist >> GetAll()
		{
			return new SuccessDataResult<List<Playlist >>(_playlistDal.GetAll(), Messages.playlistListed);

		}

		[ValidationAspect(typeof(PlaylistValidator))]
		[SecuredOperation("admin")]
		public IResult Update(Playlist playlist)
		{
			_playlistDal.Update(playlist);
			return new SuccessResult(Messages.playlistUpdated);
		}
	}
}
