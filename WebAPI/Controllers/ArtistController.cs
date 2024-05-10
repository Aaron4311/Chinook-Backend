using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ArtistController : ControllerBase
	{
		private IArtistService _artistService;

		public ArtistController(IArtistService artistService)
		{
			_artistService = artistService;
		}

		[HttpGet("GetAll")]
		public IActionResult GetAll()
		{
			var result = _artistService.GetAll();
			if (!result.Success)
			{
				return BadRequest(result.Message);
			}
			return Ok(result.Data);
		}
		[HttpGet("GetArtist")]
		public IActionResult Get(int id)
		{
			var result = _artistService.Get(id);
			if (!result.Success)
			{
				return BadRequest(result.Message);
			}
			return Ok(result.Data);
		}

		

		[HttpPost("AddArtist")]
		public IActionResult Add(Artist artist)
		{
			var result = _artistService.Add(artist);
			if (!result.Success)
			{
				return BadRequest(result.Message);
			}
			return Ok(result.Message);
		}
		[HttpPut("UpdateArtist")]
		public IActionResult Update(Artist artist)
		{
			var result = _artistService.Update(artist);
			if (!result.Success)
			{
				return BadRequest(result.Message);
			}
			return Ok(result.Message);
		}
		[HttpDelete("DeleteArtist")]
		public IActionResult Delete(int id)
		{
			var result = _artistService.Delete(id);
			if (!result.Success)
			{
				return BadRequest(result.Message);
			}
			return Ok(result.Message);
		}
	}
}
