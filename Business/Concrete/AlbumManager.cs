﻿using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Chinook_Backend.Aspects.Caching;
using Chinook_Backend.Aspects.Validation;
using Chinook_Backend.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Dtos;

namespace Business.Concrete
{
    public class AlbumManager : IAlbumService
	{
		private IAlbumDal _albumDal;

		public AlbumManager(IAlbumDal albumDal)
		{
			_albumDal = albumDal;
		}

		[CacheRemovingAspect("IAlbumService.Get")]
		[ValidationAspect(typeof(AlbumValidator))]
		public IResult Add(Album album)
		{
			_albumDal.Add(album);
			return new SuccessResult(Messages.albumAdded);
		}

		[SecuredOperation("admin")]
		[CacheRemovingAspect("IAlbumService.Get")]
		public IResult Delete(int id)
		{
			var deletedAlbum = _albumDal.Get(x => x.AlbumId == id);
			_albumDal.Delete(deletedAlbum);
			return new SuccessResult(Messages.albumDeleted);
		}

		[SecuredOperation("admin,editor,user")]
		[CachingAspect]
		public IDataResult<Album> Get(int id)
		{
			return new SuccessDataResult<Album>(_albumDal.Get(x => x.AlbumId == id),Messages.albumListed);
		}

		[SecuredOperation("admin,editor,user")]
		[CachingAspect(10)]
		public IDataResult<List<AlbumDetailsDto>> GetAlbumDetails()
		{
			return new SuccessDataResult<List<AlbumDetailsDto>>(_albumDal.GetAlbumDetails(),Messages.albumListed);
		}


		[SecuredOperation("admin,editor")]
		[CachingAspect]
		public IDataResult<List<Album>> GetAll()
		{
			return new SuccessDataResult<List<Album>>(_albumDal.GetAll(), Messages.albumListed);

		}

		[ValidationAspect(typeof(AlbumValidator))]
		[SecuredOperation("admin")]
		public IResult Update(Album album)
		{
			_albumDal.Update(album);
			return new SuccessResult(Messages.albumUpdated);
		}
	}
}
