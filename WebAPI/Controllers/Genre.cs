using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class Genre : ControllerBase
	{
		private IGenreService _genreService;
		public Genre(IGenreService genreService)
		{
			_genreService = genreService;
		}

		[HttpGet("GetAll")]
		public IActionResult GetAll()
		{
			var result = _genreService.GetAll();
			if (!result.Success)
			{
				return BadRequest(result.Message);
			}
			return Ok(result.Data);
		}
		[HttpGet("GetGenre")]
		public IActionResult Get(int id)
		{
			var result = _genreService.Get(id);
			if (!result.Success)
			{
				return BadRequest(result.Message);
			}
			return Ok(result.Data);
		}


		[HttpPost("AddGenre")]
		public IActionResult Add(Entity.Concrete.Genre genre)
		{
			var result = _genreService.Add(genre);
			if (!result.Success)
			{
				return BadRequest(result.Message);
			}
			return Ok(result.Message);
		}
		[HttpPut("UpdateGenre")]
		public IActionResult Update(Entity.Concrete.Genre genre)
		{
			var result = _genreService.Update(genre);
			if (!result.Success)
			{
				return BadRequest(result.Message);
			}
			return Ok(result.Message);
		}
		[HttpDelete("DeleteGenre")]
		public IActionResult Delete(int id)
		{
			var result = _genreService.Delete(id);
			if (!result.Success)
			{
				return BadRequest(result.Message);
			}
			return Ok(result.Message);
		}

	}
}
