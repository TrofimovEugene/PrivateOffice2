using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PrivateOffice2.Data;
using PrivateOffice2.Models;

namespace PrivateOffice2.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _context;

        public IndexModel(ILogger<IndexModel> logger,
	        ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [BindProperty]
        public IEnumerable<Course> Courses { get; set; }
        [BindProperty]
        public Course Course { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var teacherId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Courses = (await _context.Course.ToListAsync()).Where(course => course.IdTeacher == teacherId);
            return Page();
        }

        public async Task<IActionResult> OnPostCreateCourse()
        {
	        Course.IdTeacher = User.FindFirstValue(ClaimTypes.NameIdentifier);
	        await _context.Course.AddAsync(Course);

	        try
	        {
		        await _context.SaveChangesAsync();
		        return Redirect("/Index");
	        }
	        catch (DbUpdateException)
	        {
		        return BadRequest();
	        }
        }

        public async Task<IActionResult> OnPostDelete(string id)
        {
	        var course = await _context.Course.FindAsync(id);
	        if (course == null)
				return NotFound();
	        

            _context.Course.Remove(course);
	        await _context.SaveChangesAsync();

	        return Redirect("/Index");
        }
    }
}
