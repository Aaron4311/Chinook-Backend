using Business.Abstract;
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
		public IResult Add(PlaylistTrack playlistTrack)
		{
			_playlistTrackDal.Add(playlistTrack );
			return new SuccessResult();
		}

		public IResult Delete(int id)
		{
			var deletedTrack = _playlistTrackDal.Get(x => x.TrackId == id);
			_playlistTrackDal.Delete(deletedTrack);
			return new SuccessResult();
		}

		public IDataResult<PlaylistTrack > Get(int id)
		{
			return new SuccessDataResult<PlaylistTrack >(_playlistTrackDal.Get(x => x.TrackId == id));
		}

		public IDataResult<List<PlaylistTrack >> GetAll()
		{
			return new SuccessDataResult<List<PlaylistTrack >>(_playlistTrackDal.GetAll());

		}

		public IResult Update(PlaylistTrack playlistTrack)
		{
			_playlistTrackDal.Update(playlistTrack);
			return new SuccessResult();
		}
	}
}
