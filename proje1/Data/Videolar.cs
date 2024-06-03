using System.ComponentModel.DataAnnotations;

namespace proje1.Data
{
    public class Videolar
    {
        [Key]
        public int Id { get; set; }
        public string? Baslik { get; set; }
        public byte[]? VideoData { get; set; }
        public string? Kategori { get; set; }
        public string? Aciklama { get; set; }
        public byte[]? Resim { get; set; }

    }
}