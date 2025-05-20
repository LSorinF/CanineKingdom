using CanineKingdom.Models;
using System.ComponentModel.DataAnnotations;

namespace CanineKingdom.ViewModels
{
    public class RegisterViewModel : BaseClass
    {
        [Required]
        public string Username { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password), Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}