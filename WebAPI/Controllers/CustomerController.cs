using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomerController : ControllerBase
	{
		private ICustomerService _customerDal;

		public CustomerController(ICustomerService customerDal)
		{
			_customerDal = customerDal;
		}

		[HttpGet("GetAll")]
		public IActionResult GetAll()
		{
			var result = _customerDal.GetAll();
			if (!result.Success)
			{
				return BadRequest(result.Message);
			}
			return Ok(result.Data);
		}
		[HttpGet("GetCustomer")]
		public IActionResult Get(int id)
		{
			var result = _customerDal.Get(id);
			if (!result.Success)
			{
				return BadRequest(result.Message);
			}
			return Ok(result.Data);
		}



		[HttpPost("AddCustomer")]
		public IActionResult Add(Customer customer)
		{
			var result = _customerDal.Add(customer);
			if (!result.Success)
			{
				return BadRequest(result.Message);
			}
			return Ok(result.Message);
		}
		[HttpPut("UpdateCustomer")]
		public IActionResult Update(Customer customer)
		{
			var result = _customerDal.Update(customer);
			if (!result.Success)
			{
				return BadRequest(result.Message);
			}
			return Ok(result.Message);
		}
		[HttpDelete("DeleteCustomer")]
		public IActionResult Delete(int id)
		{
			var result = _customerDal.Delete(id);
			if (!result.Success)
			{
				return BadRequest(result.Message);
			}
			return Ok(result.Message);
		}

	}
}
