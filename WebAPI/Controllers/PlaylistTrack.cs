using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PlaylistTrack : ControllerBase
	{
		private IPlaylistTrackService _playlistTrackService;

		public PlaylistTrack(IPlaylistTrackService playlistTrackService)
		{
			_playlistTrackService = playlistTrackService;
		}


		[HttpGet("GetAll")]
		public IActionResult GetAll()
		{
			var result = _playlistTrackService.GetAll();
			if (!result.Success)
			{
				return BadRequest(result.Message);
			}
			return Ok(result.Data);
		}
		[HttpGet("GetPlaylistTrack")]
		public IActionResult Get(int id)
		{
			var result = _playlistTrackService.Get(id);
			if (!result.Success)
			{
				return BadRequest(result.Message);
			}
			return Ok(result.Data);
		}



		[HttpPost("AddPlaylistTrack")]
		public IActionResult Add(Entity.Concrete.PlaylistTrack playlistTrack)
		{
			var result = _playlistTrackService.Add(playlistTrack);
			if (!result.Success)
			{
				return BadRequest(result.Message);
			}
			return Ok(result.Message);
		}
		[HttpPut("UpdatePlaylistTrack")]
		public IActionResult Update(Entity.Concrete.PlaylistTrack playlistTrack)
		{
			var result = _playlistTrackService.Update(playlistTrack);
			if (!result.Success)
			{
				return BadRequest(result.Message);
			}
			return Ok(result.Message);
		}
		[HttpDelete("DeletePlaylistTrack")]
		public IActionResult Delete(int id)
		{
			var result = _playlistTrackService.Delete(id);
			if (!result.Success)
			{
				return BadRequest(result.Message);
			}
			return Ok(result.Message);
		}

	}
}
