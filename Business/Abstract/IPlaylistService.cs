using Chinook_Backend.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IPlaylistService
	{
		IDataResult<List<Playlist>> GetAll();
		IDataResult<Playlist> Get(int id);
		IResult Add(Playlist playlist);
		IResult Update(Playlist playlist);
		IResult Delete(int id);
	}
}
