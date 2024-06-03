using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace proje1.Models{
    public class LoginViewModel{
        [Required]
        [EmailAddress]
        [Display(Name = "Eposta")]
        public string Email { get; set; }=null!;

        [Required]
        [Display(Name ="Parola")]
        public string Password{ get; set; }=null!;
    }
}