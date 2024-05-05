using Chinook_Backend.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IPlaylistTrackService 
	{
		IDataResult<List<PlaylistTrack>> GetAll();
		IDataResult<PlaylistTrack> Get(int id);
		IResult Add(PlaylistTrack playlistTrack);
		IResult Update(PlaylistTrack playlistTrack);
		IResult Delete(int id);
	}
}
