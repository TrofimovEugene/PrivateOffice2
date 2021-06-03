using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrivateOffice2.Models
{
	public class Group
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public string IdGroup { get; set; }
		public string NameGroup { get; set; }

		public virtual ICollection<Course> Courses { get; set; }
	}
}