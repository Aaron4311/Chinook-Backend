using Chinook_Backend.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IInvoiceService
	{
		IDataResult<List<Invoice>> GetAll();
		IDataResult<Invoice> Get(int id);
		IResult Add(Invoice invoice);
		IResult Update(Invoice invoice);
		IResult Delete(int id);
	}
}
