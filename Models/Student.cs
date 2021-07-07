using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace PrivateOffice2.Models
{
	public class Student : IdentityUser
	{
		public string FirstName { get; set; }
		public string SecondName { get; set; }
		public string Patronymic { get; set; }
		[ForeignKey("Group")]
		public string IdGroup { get; set; }

		public virtual Group Group { get; set; }
	}
}
