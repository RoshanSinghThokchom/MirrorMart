using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models;

public class Movie
{
    public int Id { get; set; }
    public string? Shape { get; set; }
    [DataType(DataType.Date)]
    public DateTime Size { get; set; }
    public string? Material { get; set; }
    public decimal Price { get; set; }
}