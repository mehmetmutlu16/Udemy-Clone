using System.ComponentModel.DataAnnotations;

namespace proje1.Data
{
    public class Resimler
    {
        public int Id { get; set; }
        public string? Ad { get; set; }
        public byte[] Resim { get; set; } = null!;
    }
}