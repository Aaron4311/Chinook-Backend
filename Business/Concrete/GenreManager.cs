using Business.Abstract;
using Business.ValidationRules.FluentValidation;
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
	public class GenreManager : IGenreService
	{
		private IGenreDal _genreDal;

		public GenreManager(IGenreDal genreDal)
		{
			_genreDal = genreDal;
		}
		[ValidationAspect(typeof(GenreValidator))]
		public IResult Add(Genre genre)
		{
			_genreDal.Add(genre);
			return new SuccessResult();
		}

		public IResult Delete(int id)
		{
			var deletedGenre = _genreDal.Get(x => x.GenreId == id);
			_genreDal.Delete(deletedGenre);
			return new SuccessResult();
		}

		public IDataResult<Genre> Get(int id)
		{
			return new SuccessDataResult<Genre>(_genreDal.Get(x => x.GenreId == id));
		}

		public IDataResult<List<Genre>> GetAll()
		{
			return new SuccessDataResult<List<Genre>>(_genreDal.GetAll());

		}
		
		[ValidationAspect(typeof(GenreValidator))]
		public IResult Update(Genre genre)
		{
			_genreDal.Update(genre);
			return new SuccessResult();
		}
	}
}
