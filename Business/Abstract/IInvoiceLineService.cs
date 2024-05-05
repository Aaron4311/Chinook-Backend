using Chinook_Backend.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IInvoiceLineService
	{
		IDataResult<List<InvoiceLine>> GetAll();
		IDataResult<InvoiceLine> Get(int id);
		IResult Add(InvoiceLine invoiceLine);
		IResult Update(InvoiceLine invoiceLine);
		IResult Delete(int id);
	}
}
