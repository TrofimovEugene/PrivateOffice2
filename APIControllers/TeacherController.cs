using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PrivateOffice2.Data;
using PrivateOffice2.Models;

namespace PrivateOffice2.APIControllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TeacherController : ControllerBase
	{
		private readonly UserManager<Teacher> _userManager;
		private readonly SignInManager<Teacher> _signInManager;
		private readonly ApplicationDbContext _context;
		//private readonly ILogger<LoginModel> _logger;

		public TeacherController(SignInManager<Teacher> signInManager,
			UserManager<Teacher> userManager,
			ApplicationDbContext context)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_context = context;
			//_logger = logger;
		}

		public class TeacherModel : Teacher
		{
			public string Password { get; set; }
		}

		[HttpPost("RegisterTeacher")]
		public async Task<IEnumerable<IdentityError>> RegisterTeacher(TeacherModel teacher)
		{
			var result = await _userManager.CreateAsync(teacher, teacher.Password);
			return result.Succeeded ? null : result.Errors;
		}

		public class LoginModel
		{
			public string Email { get; set; }
			public string Password { get; set; }
		}


		[HttpPost("LoginTeacher")]
		public async Task<string> LoginTeacher(LoginModel login)
		{
			var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, false,
					lockoutOnFailure: false);
			if (result.Succeeded)
				return Request.Cookies[".AspNetCore.Identity.Application"];
			
			return "false";
		}

		[HttpGet]
		[Authorize]
		public async Task<IList<Teacher>> GetTeachers()
		{
			Response.Cookies.Delete(".AspNetCore.Identity.Application");
			return await _context.Users.ToListAsync();
		}
    }
}
