using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TrackController : ControllerBase
	{
		private ITrackService _trackService;

		public TrackController(ITrackService trackService)
		{
			_trackService = trackService;
		}

		[HttpGet("GetAll")]
		public IActionResult GetAll()
		{
			var result = _trackService.GetAll();
			if (!result.Success)
			{
				return BadRequest(result.Message);
			}
			return Ok(result.Data);
		}
		[HttpGet("GetTrack")]
		public IActionResult Get(int id)
		{
			var result = _trackService.Get(id);
			if (!result.Success)
			{
				return BadRequest(result.Message);
			}
			return Ok(result.Data);
		}



		[HttpPost("AddTrack")]
		public IActionResult Add(Track track)
		{
			var result = _trackService.Add(track);
			if (!result.Success)
			{
				return BadRequest(result.Message);
			}
			return Ok(result.Message);
		}
		[HttpPut("UpdateTrack")]
		public IActionResult Update(Track track)
		{
			var result = _trackService.Update(track);
			if (!result.Success)
			{
				return BadRequest(result.Message);
			}
			return Ok(result.Message);
		}
		[HttpDelete("DeleteTrack")]
		public IActionResult Delete(int id)
		{
			var result = _trackService.Delete(id);
			if (!result.Success)
			{
				return BadRequest(result.Message);
			}
			return Ok(result.Message);
		}

	}
}
