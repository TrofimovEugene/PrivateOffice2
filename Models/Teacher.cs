using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace PrivateOffice2.Models
{
    public class Teacher : IdentityUser
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Patronymic { get; set; }
    }
}
