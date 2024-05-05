using Chinook_Backend.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IAlbumService
	{
		IDataResult<List<Album>> GetAll();
		IDataResult<Album> Get(int id);
		IResult Add(Album album);
		IResult Update(Album album);
		IResult Delete(int id);
	}
}
