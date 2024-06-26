﻿using Chinook_Backend.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface ICustomerService
	{
		IDataResult<List<Customer>> GetAll();
		IDataResult<Customer> Get(int id);
		IResult Add(Customer customer);
		IResult Update(Customer customer);
		IResult Delete(int id);
	}
}
