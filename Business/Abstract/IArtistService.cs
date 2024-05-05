using Chinook_Backend.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IArtistService 
	{
		IDataResult<List<Artist>> GetAll();
		IDataResult<Artist> Get(int id);
		IResult Add(Artist artist);
		IResult Update(Artist artist);
		IResult Delete(int id);
	}
}
