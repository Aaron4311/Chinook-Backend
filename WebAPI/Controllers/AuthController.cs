using Business.Abstract;
using Entity.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private IAuthService _authService;

		public AuthController(IAuthService authService)
		{
			_authService = authService;
		}

		[HttpPost("Login")]
		public IActionResult Login(UserForLoginDto userForLoginDto)
		{
			var userToLogin = _authService.Login(userForLoginDto);
			if (!userToLogin.Success)
			{
				return BadRequest(userToLogin.Message);
			}
			var token = _authService.CreateAccessToken(userToLogin.Data);
			if (!token.Success)
			{
				return BadRequest(token.Message);
			}
			return Ok(token.Data);

		}

		[HttpPost("Register")]
		public IActionResult Register(UserForRegisterDto userForRegisterDto)
		{
			var userExists = _authService.UserExists(userForRegisterDto.Email);
			if (!userExists.Success)
			{
				return BadRequest(userExists.Message);
			}
			var resultOfRegister = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
			var token = _authService.CreateAccessToken(resultOfRegister.Data);
			if (!token.Success)
			{
				return BadRequest(token.Message);
			}
			return Ok(token.Data);	
		}
	}
}
