using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PrivateOffice2.Models;

namespace PrivateOffice2.Data
{
	public class ApplicationDbContext : IdentityDbContext<Teacher>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		public DbSet<Course> Course { get; set; }
		public DbSet<Classes> Classes { get; set; }
		public DbSet<TypeClasses> TypeClasses { get; set; }
		public DbSet<Group> Groups { get; set; }
		public DbSet<Student> Students { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			/*связь один ко многим между Teacher and Course*/
			modelBuilder.Entity<Teacher>()
				.HasMany(course => course.Course)
				.WithOne(teacher => teacher.Teacher)
				.IsRequired()
				.HasForeignKey(course => course.IdTeacher)
				.OnDelete(DeleteBehavior.Cascade);

			/*связь один ко многим между Course and Classes*/
			modelBuilder.Entity<Course>()
				.HasMany(classes => classes.Classes)
				.WithOne(course => course.Course)
				.HasForeignKey(course => course.IdCourse)
				.OnDelete(DeleteBehavior.Cascade);

			/*связь один к одному между Classes and TypeClasses*/
			modelBuilder.Entity<TypeClasses>()
				.HasMany(classes => classes.Classes)
				.WithOne(typeClasses => typeClasses.TypeClasses)
				.HasForeignKey(classes => classes.IdTypeClasses);

			/*связь один ко многим между Group and Course*/
			modelBuilder.Entity<Group>()
				.HasMany(courses => courses.Courses)
				.WithOne(group => group.Group)
				.HasForeignKey(group => group.IdGroup);

			/*связь один ко многим между Group and Student*/
			modelBuilder.Entity<Group>()
				.HasMany(student => student.Students)
				.WithOne(group => group.Group)
				.HasForeignKey(student => student.IdGroup)
				.OnDelete(DeleteBehavior.Cascade);

		}
	}
}
