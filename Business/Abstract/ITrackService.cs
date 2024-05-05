using Chinook_Backend.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface ITrackService
	{
		IDataResult<List<Track>> GetAll();
		IDataResult<Track> Get(int id);
		IResult Add(Track track);
		IResult Update(Track track);
		IResult Delete(int id);
	}
}
