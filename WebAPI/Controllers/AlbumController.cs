﻿using Business.Abstract;
using Entity.Concrete;
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
		[HttpGet("GetAlbum")]
		public IActionResult Get(int id)
		{
			var result = _albumService.Get(id);
			if (!result.Success)
			{
				return BadRequest(result.Message);
			}
			return Ok(result.Data);
		}

		[HttpGet("GetDetails")]
		public IActionResult GetAlbumDetails()
		{
			var result = _albumService.GetAlbumDetails();
			if (!result.Success)
			{
				return BadRequest(result.Message);
			}
			return Ok(result.Data);
		}

		[HttpPost("AddAlbum")]
		public IActionResult Add(Album album)
		{
			var result = _albumService.Add(album);
			if (!result.Success)
			{
				return BadRequest(result.Message);
			}
			return Ok(result.Message);
		}
		[HttpPut("UpdateAlbum")]
		public IActionResult Update(Album album)
		{
			var result = _albumService.Update(album);
			if (!result.Success)
			{
				return BadRequest(result.Message);
			}
			return Ok(result.Message);
		}
		[HttpDelete("DeleteAlbum")]
		public IActionResult Delete(int id)
		{
			var result = _albumService.Delete(id);
			if (!result.Success)
			{
				return BadRequest(result.Message);
			}
			return Ok(result.Message);
		}

	}
}
