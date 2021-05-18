using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrivateOffice2.Models
{
	public class TypeClasses
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public string IdTypeClasses { get; set; }
		public string TypeClass { get; set; }
		public virtual ICollection<Classes> Classes { get; set; }
	}
}