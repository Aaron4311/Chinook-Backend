using Chinook_Backend.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IGenreService
	{
		IDataResult<List<Genre>> GetAll();
		IDataResult<Genre> Get(int id);
		IResult Add(Genre genre);
		IResult Update(Genre genre);
		IResult Delete(int id);
	}
}
