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
	public class CustomerManager : ICustomerService
	{
		private ICustomerDal _customerDal;

		public CustomerManager(ICustomerDal customerDal)
		{
			_customerDal = customerDal;
		}
		public IResult Add(Customer customer)
		{
			_customerDal.Add(customer);
			return new SuccessResult();
		}

		public IResult Delete(int id)
		{
			var deletedCustomer = _customerDal.Get(x => x.CustomerId == id);
			_customerDal.Delete(deletedCustomer);
			return new SuccessResult();
		}

		public IDataResult<Customer> Get(int id)
		{
			return new SuccessDataResult<Customer>(_customerDal.Get(x => x.CustomerId == id));
		}

		public IDataResult<List<Customer>> GetAll()
		{
			return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());

		}

		public IResult Update(Customer customer)
		{
			_customerDal.Update(customer);
			return new SuccessResult();
		}
	}
}
