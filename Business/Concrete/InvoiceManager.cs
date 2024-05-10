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
	public class InvoiceManager : IInvoiceService
	{
		private IInvoiceDal _invoiceDal;

		public InvoiceManager(IInvoiceDal invoiceDal)
		{
			_invoiceDal = invoiceDal;
		}
		[ValidationAspect(typeof(InvoiceValidator))]
		public IResult Add(Invoice invoice)
		{
			_invoiceDal.Add(invoice);
			return new SuccessResult();
		}

		public IResult Delete(int id)
		{
			var deletedTrack = _invoiceDal.Get(x => x.InvoiceId == id);
			_invoiceDal.Delete(deletedTrack);
			return new SuccessResult();
		}

		public IDataResult<Invoice> Get(int id)
		{
			return new SuccessDataResult<Invoice>(_invoiceDal.Get(x => x.InvoiceId == id));
		}

		public IDataResult<List<Invoice>> GetAll()
		{
			return new SuccessDataResult<List<Invoice>>(_invoiceDal.GetAll());

		}
		
		[ValidationAspect(typeof(InvoiceValidator))]
		public IResult Update(Invoice invoice)
		{
			_invoiceDal.Update(invoice);
			return new SuccessResult();
		}
	}
}
