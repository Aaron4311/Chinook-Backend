﻿using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Chinook_Backend.Aspects.Caching;
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
	public class InvoiceManager : IInvoiceService
	{
		private IInvoiceDal _invoiceDal;

		public InvoiceManager(IInvoiceDal invoiceDal)
		{
			_invoiceDal = invoiceDal;
		}
		[ValidationAspect(typeof(InvoiceValidator))]
		[SecuredOperation("admin,editor")]
		[CacheRemovingAspect("IInvoiceService.Get")]
		public IResult Add(Invoice invoice)
		{
			_invoiceDal.Add(invoice);
			return new SuccessResult(Messages.invoiceAdded);
		}

		[CacheRemovingAspect("IInvoiceService.Get")]
		[SecuredOperation("admin")]
		public IResult Delete(int id)
		{
			var deletedTrack = _invoiceDal.Get(x => x.InvoiceId == id);
			_invoiceDal.Delete(deletedTrack);
			return new SuccessResult(Messages.invoiceDeleted);
		}

		[SecuredOperation("admin,editor,user")]
		[CachingAspect]
		public IDataResult<Invoice> Get(int id)
		{
			return new SuccessDataResult<Invoice>(_invoiceDal.Get(x => x.InvoiceId == id), Messages.invoiceListed);
		}

		[SecuredOperation("admin,editor")]
		[CachingAspect]
		public IDataResult<List<Invoice>> GetAll()
		{
			return new SuccessDataResult<List<Invoice>>(_invoiceDal.GetAll(), Messages.invoiceListed);

		}
		
		[ValidationAspect(typeof(InvoiceValidator))]
		[SecuredOperation("admin")]
		public IResult Update(Invoice invoice)
		{
			_invoiceDal.Update(invoice);
			return new SuccessResult(Messages.invoiceUpdated);
		}
	}
}
