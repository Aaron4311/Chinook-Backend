using Business.Abstract;
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
	public class CustomerManager : ICustomerService
	{
		private ICustomerDal _customerDal;

		public CustomerManager(ICustomerDal customerDal)
		{
			_customerDal = customerDal;
		}
		[ValidationAspect(typeof(CustomerValidator))]
		[SecuredOperation("admin,editor")]
		[CacheRemovingAspect("ICustomerService.Get")]
		public IResult Add(Customer customer)
		{
			_customerDal.Add(customer);
			return new SuccessResult(Messages.customerAdded);
		}

		[CacheRemovingAspect("ICustomerService.Get")]
		[SecuredOperation("admin")]
		public IResult Delete(int id)
		{
			var deletedCustomer = _customerDal.Get(x => x.CustomerId == id);
			_customerDal.Delete(deletedCustomer);
			return new SuccessResult(Messages.customerDeleted);
		}

		[SecuredOperation("admin,editor,user")]
		[CachingAspect]
		public IDataResult<Customer> Get(int id)
		{
			return new SuccessDataResult<Customer>(_customerDal.Get(x => x.CustomerId == id), Messages.customerListed);
		}

		[SecuredOperation("admin,editor")]
		[CachingAspect]
		public IDataResult<List<Customer>> GetAll()
		{
			return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.customerListed);

		}

		[ValidationAspect(typeof(CustomerValidator))]
		[SecuredOperation("admin")]
		public IResult Update(Customer customer)
		{
			_customerDal.Update(customer);
			return new SuccessResult(Messages.customerUpdated);
		}
	}
}
