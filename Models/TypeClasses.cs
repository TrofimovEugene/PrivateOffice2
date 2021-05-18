using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PrivateOffice2.Models
{
	public class TypeClasses
	{
		[Key]
		public string IdTypeClasses { get; set; }
		public string TypeClass { get; set; }
		public virtual ICollection<Classes> Classes { get; set; }
	}
}