using System.ComponentModel.DataAnnotations;

namespace proje1.Models
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Ad")]
        public string? Ad {get; set;}

        [Required]
        [Display(Name = "Soyad")]
        public string? Soyad {get; set;}

        [Required]
        [Display(Name = "Öğrenci mi? Öğretmen mi?")]
        public int? OgrenciMi {get; set;}

        [Required]
        [EmailAddress]
        [Display(Name = "Eposta")]
        public string? Eposta {get; set;}

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Parola")]
        public string? Sifre {get; set;}

    }
}