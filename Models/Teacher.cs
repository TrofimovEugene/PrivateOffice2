using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace PrivateOffice2.Models
{
    public class Teacher : IdentityUser
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Patronymic { get; set; }
        public string Role { get; set; }
        
        public virtual ICollection<Course> Course { get; set; }
    }
}
