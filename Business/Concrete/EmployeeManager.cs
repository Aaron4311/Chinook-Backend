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
	public class EmployeeManager : IEmployeeService
	{
		private IEmployeeDal _employeeDal;

		public EmployeeManager(IEmployeeDal employeeDal)
		{
			_employeeDal = employeeDal;
		}
		[ValidationAspect(typeof(EmployeeValidator))]
		public IResult Add(Employee employee)
		{
			_employeeDal.Add(employee);
			return new SuccessResult();
		}

		public IResult Delete(int id)
		{
			var deletedEmployee = _employeeDal.Get(x => x.EmployeeId == id);
			_employeeDal.Delete(deletedEmployee);
			return new SuccessResult();
		}

		public IDataResult<Employee> Get(int id)
		{
			return new SuccessDataResult<Employee>(_employeeDal.Get(x => x.EmployeeId == id));
		}

		public IDataResult<List<Employee>> GetAll()
		{
			return new SuccessDataResult<List<Employee>>(_employeeDal.GetAll());

		}

		[ValidationAspect(typeof(EmployeeValidator))]
		public IResult Update(Employee employee)
		{
			_employeeDal.Update(employee);
			return new SuccessResult();
		}
	}
}
