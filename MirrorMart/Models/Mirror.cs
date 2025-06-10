using System.ComponentModel.DataAnnotations;

namespace MirrorMart.Models
{
    public class Mirror
    {
        public int Id { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        public string Material { get; set; }

        [Required]
        public string Size { get; set; }

        [Required]
        public string Shape { get; set; }
    }
}
