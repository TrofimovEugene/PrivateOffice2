using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PrivateOffice2.Models;

namespace PrivateOffice2.Areas.Identity.Pages.Account.Manage
{
    public class PersonalDataModel : PageModel
    {
        private readonly UserManager<Teacher> _userManager;
        private readonly ILogger<PersonalDataModel> _logger;

        public PersonalDataModel(
            UserManager<Teacher> userManager,
            ILogger<PersonalDataModel> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        [BindProperty]
        public PersonalUserData PersonalData { get; set; }

        public class PersonalUserData
        {
	        [Display(Name = "First name")]
            public string FirstName { get; set; }
            [Display(Name = "Second name")]
            public string SecondName { get; set; }
            [Display(Name = "Patronymic")]
            public string Patronymic { get; set; }
        }


        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
	            return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            PersonalData = new PersonalUserData()
            {
                FirstName = user.FirstName,
                SecondName = user.SecondName,
                Patronymic = user.Patronymic
            };

            return Page();
        }
    }
}