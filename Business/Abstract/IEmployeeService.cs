﻿using Chinook_Backend.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IEmployeeService
	{
		IDataResult<List<Employee>> GetAll();
		IDataResult<Employee> Get(int id);
		IResult Add(Employee employee);
		IResult Update(Employee employee);
		IResult Delete(int id);
	}
}
