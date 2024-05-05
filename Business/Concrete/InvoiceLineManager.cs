using Business.Abstract;
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
	public class InvoiceLineManager : IInvoiceLineService
	{
		private IInvoiceLineDal _invoiceLineDal;

		public InvoiceLineManager(IInvoiceLineDal invoiceLineDal)
		{
			_invoiceLineDal = invoiceLineDal;
		}
		public IResult Add(InvoiceLine invoice)
		{
			_invoiceLineDal.Add(invoice);
			return new SuccessResult();
		}

		public IResult Delete(int id)
		{
			var deletedInvoiceLine = _invoiceLineDal.Get(x => x.InvoiceLineId == id);
			_invoiceLineDal.Delete(deletedInvoiceLine);
			return new SuccessResult();
		}

		public IDataResult<InvoiceLine> Get(int id)
		{
			return new SuccessDataResult<InvoiceLine>(_invoiceLineDal.Get(x => x.InvoiceLineId == id));
		}

		public IDataResult<List<InvoiceLine>> GetAll()
		{
			return new SuccessDataResult<List<InvoiceLine>>(_invoiceLineDal.GetAll());

		}

		public IResult Update(InvoiceLine invoice)
		{
			_invoiceLineDal.Update(invoice);
			return new SuccessResult();
		}
	}
}
