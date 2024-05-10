using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AlbumController : ControllerBase
	{
		private IAlbumService _albumService;

		public AlbumController(IAlbumService albumService)
		{
			_albumService = albumService;
		}

		[HttpGet("GetAll")]
		public IActionResult GetAll()
		{
			var result = _albumService.GetAll();
			if (!result.Success)
			{
				return BadRequest(result.Message);
			}
			return Ok(result.Data);	
		}

	}
}
