using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrivateOffice2.Models
{
	public class Classes
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public string IdClasses { get; set; }
		[ForeignKey("TypeClasses")]
		public string IdTypeClasses { get; set; }
		[ForeignKey("Course")]
		public string IdCourse { get; set; }

		public string NameClasses { get; set; }
		public TimeSpan StartTime { get; set; }
		public TimeSpan EndTime { get; set; }
		[Column(TypeName = "date")]
		public DateTime DateClasses { get; set; }
		public string DaysWeek { get; set; }
		public string Cabinet { get; set; }
		public string ReplayClasses { get; set; }

		public virtual Course Course { get; set; }
		public virtual TypeClasses TypeClasses { get; set; }
	}
}