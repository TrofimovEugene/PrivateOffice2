using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PrivateOffice2.Models
{
	public class Group
	{
		[Key]
		public int IdGroup { get; set; }
		public string NameGroup { get; set; }

		public virtual ICollection<Course> Course { get; set; }
	}
}