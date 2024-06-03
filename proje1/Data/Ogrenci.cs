using System.ComponentModel.DataAnnotations;

namespace proje1.Data
{
    public class Ogrenci
    {
        [Key]
        public int Idd { get; set; }
        public string? Ad { get; set; }
        public string? Soyad { get; set; }
        public int? OgrenciMi { get; set; }
        public string Eposta { get; set; } = null!;
        public string Sifre { get; set; } = null!;

    }
}