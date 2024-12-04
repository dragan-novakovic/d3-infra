
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _3dmarketplace.src.Models
{


    [Table("Products")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required int Id { get; set; }
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
        public required Category.Category Category { get; set; }
        public required UserMetadata User { get; set; }
        public ICollection<Review>? Reviews { get; set; }


        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Price: {Price}, Description: {Description}, Stock: {Stock}, UserId: {UserId}, CategoryId: {CategoryId}, Category: {Category}, User: {User}, Reviews: {Reviews?.Count}";

        }
    }

}