using InstitutionManagmentSystem.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace InstitutionManagmentSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }

    }
}
