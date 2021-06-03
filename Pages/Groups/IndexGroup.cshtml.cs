using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PrivateOffice2.Data;
using PrivateOffice2.Models;

namespace PrivateOffice2.Pages.Groups
{
    public class IndexGroup : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexGroup(ApplicationDbContext context)
        {
            _context = context;
        }
        
        [BindProperty]
        public IEnumerable<Group> Groups { get; set; }

        [BindProperty]
        public Group Group { get; set; }

        public async Task<IActionResult> OnGet()
        {
            Groups = await _context.Groups.ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostCreateGroups()
        {
	        await _context.Groups.AddAsync(Group);

            try
            {
	            await _context.SaveChangesAsync();
	            await OnGet();
            }
            catch (DbUpdateException)
            {
	            return BadRequest();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostDelete(string id)
        {
	        var group = await _context.Groups.FindAsync(id);

	        if (group == null)
		        return NotFound();


	        _context.Groups.Remove(group);
	        await _context.SaveChangesAsync();


	        return Redirect("/Groups/IndexGroup");
        }
    }
}