using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class InvoiceLineController : ControllerBase
	{
		private IInvoiceLineService _invoiceLineService;

		public InvoiceLineController(IInvoiceLineService invoiceLineService)
		{
			_invoiceLineService = invoiceLineService;
		}

		[HttpGet("GetAll")]
		public IActionResult GetAll()
		{
			var result = _invoiceLineService.GetAll();
			if (!result.Success)
			{
				return BadRequest(result.Message);
			}
			return Ok(result.Data);
		}
		[HttpGet("GetInvoiceLine")]
		public IActionResult Get(int id)
		{
			var result = _invoiceLineService.Get(id);
			if (!result.Success)
			{
				return BadRequest(result.Message);
			}
			return Ok(result.Data);
		}



		[HttpPost("AddInvoiceLine")]
		public IActionResult Add(InvoiceLine invoiceLine)
		{
			var result = _invoiceLineService.Add(invoiceLine);
			if (!result.Success)
			{
				return BadRequest(result.Message);
			}
			return Ok(result.Message);
		}
		[HttpPut("UpdateInvoiceLine")]
		public IActionResult Update(InvoiceLine invoiceLine)
		{
			var result = _invoiceLineService.Update(invoiceLine);
			if (!result.Success)
			{
				return BadRequest(result.Message);
			}
			return Ok(result.Message);
		}
		[HttpDelete("DeleteInvoiceLine")]
		public IActionResult Delete(int id)
		{
			var result = _invoiceLineService.Delete(id);
			if (!result.Success)
			{
				return BadRequest(result.Message);
			}
			return Ok(result.Message);
		}
	}
}
