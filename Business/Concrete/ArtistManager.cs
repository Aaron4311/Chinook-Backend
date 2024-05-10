using Business.Abstract;
using Business.BusinessAspects.Autofac;
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
	public class ArtistManager : IArtistService
	{
		private IArtistDal _artistDal;

		public ArtistManager(IArtistDal artistDal)
		{
			_artistDal = artistDal;
		}
		[ValidationAspect(typeof(ArtistValidator))]
		[SecuredOperation("admin,editor")]
		public IResult Add(Artist artist)
		{
			_artistDal.Add(artist);
			return new SuccessResult();
		}

		[SecuredOperation("admin")]
		public IResult Delete(int id)
		{
			var deletedArtist = _artistDal.Get(x => x.ArtistId == id);
			_artistDal.Delete(deletedArtist);
			return new SuccessResult();
		}

		[SecuredOperation("admin,editor,user")]
		public IDataResult<Artist> Get(int id)
		{
			return new SuccessDataResult<Artist>(_artistDal.Get(x => x.ArtistId == id));
		}

		[SecuredOperation("admin,editor")]
		public IDataResult<List<Artist>> GetAll()
		{
			return new SuccessDataResult<List<Artist>>(_artistDal.GetAll());

		}

		[SecuredOperation("admin")]
		[ValidationAspect(typeof(ArtistValidator))]
		public IResult Update(Artist artist)
		{
			_artistDal.Update(artist);
			return new SuccessResult();
		}
	}
}
