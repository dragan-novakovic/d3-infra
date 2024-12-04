using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ProductDto
{
    [Required]
    public required string Name { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    public string? Description { get; set; }
    public int Stock { get; set; }
    [ForeignKey("UserId")]
    public string? UserId { get; set; }
    [ForeignKey("CategoryId")]
    public required int CategoryId { get; set; }

}