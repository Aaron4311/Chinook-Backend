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
	public class MediaTypeManager : IMediaTypeService
	{
		private IMediaTypeDal _mediaTypeDal;

		public MediaTypeManager(IMediaTypeDal mediaTypeDal)
		{
			_mediaTypeDal = mediaTypeDal;
		}

		[ValidationAspect(typeof(MediaTypeValidator))]

		public IResult Add(MediaType mediaType)
		{
			_mediaTypeDal.Add(mediaType);
			return new SuccessResult();
		}

		public IResult Delete(int id)
		{
			var deletedMediaType = _mediaTypeDal.Get(x => x.MediaTypeId == id);
			_mediaTypeDal.Delete(deletedMediaType);
			return new SuccessResult();
		}

		public IDataResult<MediaType> Get(int id)
		{
			return new SuccessDataResult<MediaType>(_mediaTypeDal.Get(x => x.MediaTypeId == id));
		}

		public IDataResult<List<MediaType>> GetAll()
		{
			return new SuccessDataResult<List<MediaType>>(_mediaTypeDal.GetAll());

		}

		[ValidationAspect(typeof(MediaTypeValidator))]
		public IResult Update(MediaType mediaType)
		{
			_mediaTypeDal.Update(mediaType);
			return new SuccessResult();
		}
	}
}
