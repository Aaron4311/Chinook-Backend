﻿using Business.Abstract;
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
		public IResult Add(Playlist playlist)
		{
			_playlistDal.Add(playlist);
			return new SuccessResult();
		}

		public IResult Delete(int id)
		{
			var deletedPlaylist = _playlistDal.Get(x => x.PlaylistId == id);
			_playlistDal.Delete(deletedPlaylist);
			return new SuccessResult();
		}

		public IDataResult<Playlist > Get(int id)
		{
			return new SuccessDataResult<Playlist >(_playlistDal.Get(x => x.PlaylistId == id));
		}

		public IDataResult<List<Playlist >> GetAll()
		{
			return new SuccessDataResult<List<Playlist >>(_playlistDal.GetAll());

		}

		public IResult Update(Playlist playlist)
		{
			_playlistDal.Update(playlist);
			return new SuccessResult();
		}
	}
}