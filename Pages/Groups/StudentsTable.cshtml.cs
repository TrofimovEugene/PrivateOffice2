using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PrivateOffice2.Data;
using PrivateOffice2.Models;

namespace PrivateOffice2.Pages.Groups
{
	[Authorize]
	public class StudentsTableModel : PageModel
    {
	    private readonly ApplicationDbContext _context;
	    private readonly UserManager<Student> _userManager;

		public StudentsTableModel(ApplicationDbContext context,
			UserManager<Student> userManager)
	    {
		    _context = context;
		    _userManager = userManager;
	    }

		[BindProperty]
		public IList<Student> Students { get; set; }

		[BindProperty]
		public InputModel Input { get; set; }

		[BindProperty]
		public IList<Group> Groups { get; set; }

		public class InputModel
		{
			[Required]
			[Display(Name = "First name")]
			public string FirstName { get; set; }

			[Required]
			[Display(Name = "Second name")]
			public string SecondName { get; set; }

			[Required]
			[Display(Name = "Patronymic")]
			public string Patronymic { get; set; }

			[Required]
			[EmailAddress]
			[Display(Name = "Email")]
			public string Email { get; set; }

			[Required]
			[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
			[DataType(DataType.Password)]
			[Display(Name = "Password")]
			public string Password { get; set; }

			[DataType(DataType.Password)]
			[Display(Name = "Confirm password")]
			[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
			public string ConfirmPassword { get; set; }


		}

        public async Task OnGet()
        {
	        var students = await _context.Students.ToListAsync();
	        Students = students;

	        var groups = await _context.Groups.ToListAsync();
	        Groups = groups;
        }

		public async Task<IActionResult> OnPostCreateStudent(string idgroup)
		{
			if (!ModelState.IsValid) 
				return NotFound();
			var student = new Student
			{
				FirstName = Input.FirstName,
				SecondName = Input.SecondName,
				Patronymic = Input.Patronymic,
				UserName = Input.Email,
				Email = Input.Email,
				IdGroup = idgroup
			};

			var result = await _userManager.CreateAsync(student, Input.Password);
			if (result.Succeeded)
			{
				return Redirect("/StudentsTable");
			}

			return NotFound();

		}

	}
}
