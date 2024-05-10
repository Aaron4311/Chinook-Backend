using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MediaTypeController : ControllerBase
	{
		private IMediaTypeService _mediaTypeService;

		public MediaTypeController(IMediaTypeService mediaTypeService)
		{
			_mediaTypeService = mediaTypeService;

		}

		[HttpGet("GetAll")]
		public IActionResult GetAll()
		{
			var result = _mediaTypeService.GetAll();
			if (!result.Success)
			{
				return BadRequest(result.Message);
			}
			return Ok(result.Data);
		}
		[HttpGet("GetMediaType")]
		public IActionResult Get(int id)
		{
			var result = _mediaTypeService.Get(id);
			if (!result.Success)
			{
				return BadRequest(result.Message);
			}
			return Ok(result.Data);
		}



		[HttpPost("AddMediaType")]
		public IActionResult Add(MediaType mediaType)
		{
			var result = _mediaTypeService.Add(mediaType);
			if (!result.Success)
			{
				return BadRequest(result.Message);
			}
			return Ok(result.Message);
		}
		[HttpPut("UpdateMediaType")]
		public IActionResult Update(MediaType mediaType)
		{
			var result = _mediaTypeService.Update(mediaType);
			if (!result.Success)
			{
				return BadRequest(result.Message);
			}
			return Ok(result.Message);
		}
		[HttpDelete("DeleteMediaType")]
		public IActionResult Delete(int id)
		{
			var result = _mediaTypeService.Delete(id);
			if (!result.Success)
			{
				return BadRequest(result.Message);
			}
			return Ok(result.Message);
		}


	}
}
