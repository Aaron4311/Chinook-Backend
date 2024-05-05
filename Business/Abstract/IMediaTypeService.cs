using Chinook_Backend.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IMediaTypeService
	{
		IDataResult<List<MediaType>> GetAll();
		IDataResult<MediaType> Get(int id);
		IResult Add(MediaType mediaType);
		IResult Update(MediaType mediaType);
		IResult Delete(int id);
	}
}
