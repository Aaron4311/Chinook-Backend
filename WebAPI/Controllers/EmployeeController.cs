using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		IEmployeeService _employeeService;

		public EmployeeController(IEmployeeService employeeService)
		{
			_employeeService = employeeService;
		}

		[HttpGet("GetAll")]
		public IActionResult GetAll()
		{
			var result = _employeeService.GetAll();
			if (!result.Success)
			{
				return BadRequest(result.Message);
			}
			return Ok(result.Data);
		}
		[HttpGet("GetEmployee")]
		public IActionResult Get(int id)
		{
			var result = _employeeService.Get(id);
			if (!result.Success)
			{
				return BadRequest(result.Message);
			}
			return Ok(result.Data);
		}



		[HttpPost("AddEmployee")]
		public IActionResult Add(Employee employee)
		{
			var result = _employeeService.Add(employee);
			if (!result.Success)
			{
				return BadRequest(result.Message);
			}
			return Ok(result.Message);
		}
		[HttpPut("UpdateEmployee")]
		public IActionResult Update(Employee employee)
		{
			var result = _employeeService.Update(employee);
			if (!result.Success)
			{
				return BadRequest(result.Message);
			}
			return Ok(result.Message);
		}
		[HttpDelete("DeleteEmployee")]
		public IActionResult Delete(int id)
		{
			var result = _employeeService.Delete(id);
			if (!result.Success)
			{
				return BadRequest(result.Message);
			}
			return Ok(result.Message);
		}
	}
}
