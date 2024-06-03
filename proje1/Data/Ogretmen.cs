using System.ComponentModel.DataAnnotations;

namespace proje1.Data
{
    public class Ogretmen
    {
        [Key]
        public int Id { get; set; }
        public string? Ad { get; set; }
        public string? Soyad { get; set; }
        public string? Eposta { get; set; }
        public string? Sifre { get; set; }

    }
}